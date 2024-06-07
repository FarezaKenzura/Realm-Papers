using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUIResize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private int animId = -1;

    [Header("General Config")]
    [SerializeField] private float scaleFactor = 1.1f;
    [SerializeField] private float hoverScaleFactor = 1.1f;

    private Vector3 textScale;
    private Image hoverImage;

    private void Awake()
    {
        textScale = GetComponent<RectTransform>().transform.localScale;
        hoverImage = GetComponentInChildren<Image>();

        hoverImage.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeanTween.cancel(animId);
        animId = LeanTween.scale(GetComponent<RectTransform>(), textScale, 0.15f)
            .setEaseInOutSine().id;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animId != -1) LeanTween.cancel(animId);
        animId = LeanTween.scale(GetComponent<RectTransform>(), textScale * scaleFactor, 0.15f)
            .setEaseInOutSine().id;

        LeanTween.cancel(hoverImage.gameObject, false);
        hoverImage.gameObject.SetActive(true);
        LeanTween.scale(hoverImage.rectTransform, textScale * hoverScaleFactor, 0.15f)
            .setEaseInOutSine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(animId);
        animId = LeanTween.scale(GetComponent<RectTransform>(), textScale, 0.15f)
            .setEaseInOutSine().id;

        LeanTween.cancel(hoverImage.gameObject, false);
        LeanTween.scale(hoverImage.rectTransform, textScale, 0.15f)
            .setEaseInOutSine().setOnComplete(() => hoverImage.gameObject.SetActive(false));
    }
}