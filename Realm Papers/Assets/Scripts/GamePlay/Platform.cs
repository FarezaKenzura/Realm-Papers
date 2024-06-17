using UnityEngine;
using UniRx;
using System;

public class Platform : MonoBehaviour
{
    [Header("Speed Properties")]
    [Tooltip("Kecepatan pergerakan platform.")]
    [SerializeField] private float moveDuration = 2f;
    private bool isMoving;
    private IDisposable moveSubscription;

    public bool IsMoving => isMoving;

    public void MoveToInitialPosition(Vector3[] originalControlPoints)
    {
        Vector3[] reversedControlPoints = GetReversedControlPoints(originalControlPoints);
        MoveAlongPath(reversedControlPoints);
    }

    public void MoveAlongPath(Vector3[] controlPoints)
    {
        moveSubscription?.Dispose();
        isMoving = true;
        float startTime = Time.time;

        moveSubscription = Observable.EveryFixedUpdate()
            .Select(_ => (Time.time - startTime) / moveDuration)
            .TakeWhile(t => t <= 1f)
            .Subscribe(t =>
            {
                transform.position = BezierUtility.CalculateBezierPoint(t, controlPoints);
            }, () =>
            {
                isMoving = false;
            })
            .AddTo(this);
    }

    private Vector3[] GetReversedControlPoints(Vector3[] originalControlPoints)
    {
        Vector3[] reversedControlPoints = new Vector3[originalControlPoints.Length];
        for (int i = 0; i < originalControlPoints.Length; i++)
        {
            reversedControlPoints[i] = originalControlPoints[originalControlPoints.Length - 1 - i];
        }

        reversedControlPoints[0] = transform.position;
        return reversedControlPoints;
    }
}