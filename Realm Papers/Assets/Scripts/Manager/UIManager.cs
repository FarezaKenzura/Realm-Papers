using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image carriedObjectImage;
    [SerializeField] private Sprite emptySprite; // Sprite kosong untuk ketika tidak membawa objek

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCarriedObjectImage(Sprite sprite)
    {
        carriedObjectImage.sprite = sprite ?? emptySprite;
    }
}