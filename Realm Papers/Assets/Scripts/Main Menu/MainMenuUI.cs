using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PaperRealms.UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        public void StartGame()
        {
            SceneManager.LoadScene("Game Scene");
        }

        public void TogglePanel(GameObject panel)
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

        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
