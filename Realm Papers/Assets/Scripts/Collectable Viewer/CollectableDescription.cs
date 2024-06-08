using System;
using PaperRealm.System.GameManager;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealms.UI.Collectable
{
    public class CollectableDescription : MonoBehaviour 
    {
        [Header("UI Components")]
        [SerializeField] private Image cardImage;
        [SerializeField] private TMP_Text subjectText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text sincerelyText;

        [Header("Animation Settings")]
        private float animationDuration = 0.5f;
        private Vector3 openScale = new Vector3(1, 1, 1);
        private Vector3 closedScale = new Vector3(0f, 0f, 0f);

        private bool isAnimating = false;
        public bool IsVisible => gameObject.activeSelf && transform.localScale == openScale;

        private void Update()
        {
            if (CanInteract() && Input.anyKeyDown)
                CloseCollectable();
        }

        private bool CanInteract() => IsVisible && !isAnimating;

        public void ResetDescription() 
        {
            cardImage.gameObject.SetActive(false);
            subjectText.text = descriptionText.text = sincerelyText.text = "";
        }

        public void SetDescription(Sprite sprite, string subject, string description, string sincerely) 
        {
            cardImage.gameObject.SetActive(true);
            cardImage.sprite = sprite;
            subjectText.text = subject;
            descriptionText.text = description;
            sincerelyText.text = sincerely;
        }

        public void OpenCollectable()
        {
            if (isAnimating) return;
            isAnimating = true;
            gameObject.SetActive(true);
            transform.localScale = closedScale;

            LeanTween.scale(gameObject, openScale, animationDuration)
                .setEase(LeanTweenType.easeOutBack)
                .setOnComplete(() => { GameManager.Instance.CurrentState = GameState.Collectable; isAnimating = false; });
        }

        public void CloseCollectable()
        {
            if (isAnimating) return;
            isAnimating = true;

            LeanTween.scale(gameObject, closedScale, animationDuration)
                .setEase(LeanTweenType.easeInBack)
                .setOnComplete(() =>
                {
                    gameObject.SetActive(false);
                    Observable.Timer(TimeSpan.FromSeconds(0.5f)).Subscribe(_ => { GameManager.Instance.CurrentState = GameState.GamePlay; }).AddTo(this);
                    isAnimating = false;
                    ResetDescription();
                });
        }
    }
}
