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
    public Button continueButton;
    public Button settingButton;
    public Button mainMenuButton;

    private bool isPause = false;
    private bool isSettingOpen = false;

    void Start()
    {
        continueButton.onClick.AddListener(Continue);
        settingButton.onClick.AddListener(OpenSetting);
        mainMenuButton.onClick.AddListener(ToMainMenu);
    }

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
            
            AudioManager.instance.PlaySFX("Klik Button");
        }
    }

    private void Continue()
    {
        pauseMenuPanel.SetActive(false);
        Cursor.visible = false;

        AudioManager.instance.PlaySFX("Klik Button");
        isPause = false;
    }

    private void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Cursor.visible = true;

        AudioManager.instance.PlaySFX("Klik Button");
        isPause = true;
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);

        AudioManager.instance.PlaySFX("Klik Button");
        isSettingOpen = true;
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);

        AudioManager.instance.PlaySFX("Klik Button");
        isSettingOpen = false;
    }

    public void ToMainMenu()
    {
        //GameManager.instance.TransitionScene("Main Menu");
        SceneManager.LoadScene("Main Menu");
        AudioManager.instance.PlaySFX("Klik Button");
    }
}
