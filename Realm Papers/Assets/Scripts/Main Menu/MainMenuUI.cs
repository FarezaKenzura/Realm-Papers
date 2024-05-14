using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PaperRealms.UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button localMultiplayerButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;
        
        [Header("Panel")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        private void Start()
        {
            startGameButton.onClick.AddListener(StartGame);
            localMultiplayerButton.onClick.AddListener(LocalMultiplayer);
            settingButton.onClick.AddListener(() => TogglePanel(settingsPanel));
            creditsButton.onClick.AddListener(() => TogglePanel(creditsPanel));
            exitButton.onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Game Scene");
        }

        private void LocalMultiplayer()
        {
            SceneManager.LoadScene("Game Multiplayer Scene");
        }

        private void TogglePanel(GameObject panel)
        {
            if (panel == settingsPanel)
            {
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(true);
                creditsPanel.SetActive(false);
            }
            else if (panel == creditsPanel)
            {
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                creditsPanel.SetActive(true);
            }
        }

        private void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
