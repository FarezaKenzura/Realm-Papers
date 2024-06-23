using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.System.Fade
{
    public class FadeManager : MonoBehaviour
    {
        private static FadeManager instance;
        [SerializeField] private CanvasGroup fadePanel;
        [SerializeField] private float animTime;

        private bool isFading = false;

        private void Awake()
        {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);

            EventManager.SetFade += SetFade;
        }

        private void OnDestroy()
        {
            EventManager.SetFade -= SetFade;
        }

        private void SetFade(bool isFadeIn)
        {
            if (isFading) return;

            isFading = true;
            float a = isFadeIn ? 1f : 0f;

            LeanTween.alphaCanvas(fadePanel, a, animTime)
                .setEaseInOutSine()
                .setOnComplete(() =>
                {

                    if (isFadeIn)
                    {
                        EventManager.OnFadeInComplete?.Invoke();
                    }
                    else
                    {
                        EventManager.OnFadeOutComplete?.Invoke();
                    }

                    isFading = false;
                });

        }
    }
}
