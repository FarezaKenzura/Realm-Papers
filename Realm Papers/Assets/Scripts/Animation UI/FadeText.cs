using UnityEngine;

public class FadeText : MonoBehaviour {
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float fadeOutDuration;

    private void OnEnable()
    {
        FadeIn();
    }

    private void OnDisable()
    {
        FadeOut();
    }

    private void FadeIn()
    {
        canvasGroup.alpha = 0f;
        LeanTween.alphaCanvas(canvasGroup, 1f, fadeInDuration).setOnComplete(() => {
            canvasGroup.alpha = 1f;
        });
    }

    private void FadeOut()
    {
        canvasGroup.alpha = 1f;
        LeanTween.alphaCanvas(canvasGroup, 0f, fadeOutDuration).setOnComplete(() => {
            canvasGroup.alpha = 0f;
        });
    }
}