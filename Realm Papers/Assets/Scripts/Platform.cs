using UnityEngine;
using UniRx;
using System;

public class Platform : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Kecepatan pergerakan platform.")]
    [SerializeField] private float moveDuration = 2f;

    private Vector3 initialPosition;
    private IDisposable moveSubscription;
    
    private void Start()
    {
        initialPosition = transform.position;
    }

    public void MoveToInitialPosition()
    {
        MoveAlongPath(new Vector3[] { transform.position, initialPosition });
    }

    public void MoveAlongPath(Vector3[] controlPoints)
    {
        moveSubscription?.Dispose();
        float startTime = Time.time;

        moveSubscription = Observable.EveryUpdate()
            .Select(_ => (Time.time - startTime) / moveDuration)
            .TakeWhile(t => t <= 1f)
            .Subscribe(t =>
            {
                transform.position = BezierUtility.CalculateBezierPoint(t, controlPoints);

                if (t >= 1f)
                {
                    moveSubscription.Dispose();
                }
            })
            .AddTo(this);;
    }
}