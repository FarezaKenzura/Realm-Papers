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

    private ReactiveProperty<bool> isActivated = new ReactiveProperty<bool>(false);
    private bool isInitialized = false;

    private void Start()
    {
        isActivated.Subscribe(OnActivatedChanged).AddTo(this);
    }

    public bool IsInitialized => isInitialized;

    public void Interact()
    {
        if (platformMover.IsMoving)
        {
            Debug.Log("Cannot interact while the platform is moving.");
            return;
        }

        isActivated.Value = !isActivated.Value;
    }

    private void OnActivatedChanged(bool activated)
    {
        if (!IsInitialized)
        {
            isInitialized = true;
            return;
        }

        if (activated)
            platformMover.MoveAlongPath(controlPoints);
        else
            platformMover.MoveToInitialPosition(controlPoints);
    }
}