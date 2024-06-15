using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealms.UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;
        
        [Header("Panel")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        [Header("Animation")]
        [SerializeField] private float buttonFadeInDuration = 0.5f;
        [SerializeField] private float buttonFadeInDelay = 0.2f;

        private void Start()
        {
            EventManager.SetFade?.Invoke(false);
            SetButtonListeners();
            HandleMainMenuActive();
            EventManager.OnMainMenuActive += HandleMainMenuActive;
        }

        private void OnDestroy()
        {
            EventManager.OnMainMenuActive -= HandleMainMenuActive;
        }

        private void SetButtonListeners()
        {
            startGameButton.onClick.AddListener(StartGame);
            settingButton.onClick.AddListener(() => TogglePanel(settingsPanel));
            creditsButton.onClick.AddListener(() => TogglePanel(creditsPanel));
            exitButton.onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            EventManager.OnNextLevel?.Invoke();
        }

        private void HandleMainMenuActive()
        {
            StartCoroutine(FadeInButtons());
        }

        private void TogglePanel(GameObject panel)
        {
            ResetButtonAlpha();
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(panel == settingsPanel);
            creditsPanel.SetActive(panel == creditsPanel);
            EventManager.OnMainMenuDeactivated?.Invoke(true);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        #region Utils
        private Button[] GetMainMenuButtons()
        {
            return new Button[] { startGameButton, settingButton, creditsButton, exitButton };
        }

        private IEnumerator FadeInButtons()
        {
            foreach (Button button in GetMainMenuButtons())
            {
                CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();
                button.interactable = false;
                if (canvasGroup != null)
                {
                    LeanTween.alphaCanvas(canvasGroup, 1f, buttonFadeInDuration)
                         .setEase(LeanTweenType.easeInOutQuad)
                         .setOnComplete(() => button.interactable = true);
                    yield return new WaitForSeconds(buttonFadeInDelay);
                }
            }
        }

        private void ResetButtonAlpha()
        {
            foreach (Button button in GetMainMenuButtons())
            {
                CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();
                if (canvasGroup != null)
                {
                    canvasGroup.alpha = 0f;
                }
            }
        }
        #endregion
    }
}
