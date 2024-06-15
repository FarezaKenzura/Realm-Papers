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

    [Header("Visual References")]
    [Tooltip("Sprite saat mekanisme aktif.")]
    [SerializeField] private Sprite activeSprite;

    [Tooltip("Sprite saat mekanisme tidak aktif.")]
    [SerializeField] private Sprite inactiveSprite;

    private SpriteRenderer spriteRenderer;

    private ReactiveProperty<bool> isActivated = new ReactiveProperty<bool>(false);
    private bool isInitialized = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        UpdateVisualState(activated);

        if (activated)
            platformMover.MoveAlongPath(controlPoints);
        else
            platformMover.MoveToInitialPosition(controlPoints);
    }

    private void UpdateVisualState(bool activated)
    {
        spriteRenderer.sprite = activated ? activeSprite : inactiveSprite;
    }
}