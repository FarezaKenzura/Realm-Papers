using UnityEngine;
using UniRx;

public class Mechanism : MonoBehaviour, IInteractable 
{
    [Header("Platform Reference")]
    [Tooltip("Referensi ke objek platform yang akan digerakkan.")]
    [SerializeField] private Platform platformMover;

    [Header("Target Positions")]
    [Tooltip("Titik kontrol untuk jalur melengkung.")]
    [SerializeField] private Vector3[] controlPoints;

    public ReactiveProperty<bool> isActivated = new ReactiveProperty<bool>(false);

    private void Start()
    {
        // Berlangganan perubahan status isActivated
        isActivated
            .Subscribe(activated =>
            {
                Debug.Log("IsActivated changed: " + activated);
                if (activated)
                {
                    platformMover.MoveAlongPath(controlPoints);
                }
                else
                {
                    platformMover.MoveToInitialPosition();
                }
            })
            .AddTo(this);
    }

    public bool IsActivated => isActivated.Value;

    public void Interact()
    {
        Debug.Log("Interact called. Current state: " + isActivated.Value);
        isActivated.Value = !isActivated.Value;
        Debug.Log("New state: " + isActivated.Value);
    }
}