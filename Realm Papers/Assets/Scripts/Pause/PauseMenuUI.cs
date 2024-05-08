using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject settingPanel;

    private bool isPause = false;
    private bool isSettingOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingOpen)
            {
                CloseSetting();
            }
            else if (isPause)
            {
                Continue();
                CloseSetting();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Continue()
    {
        pauseMenuPanel.SetActive(false);
        isPause = false;
    }

    private void Pause()
    {
        pauseMenuPanel.SetActive(true);
        isPause = true;
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
        isSettingOpen = true;
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
        isSettingOpen = false;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
