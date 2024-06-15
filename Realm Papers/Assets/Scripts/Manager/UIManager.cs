using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [Header("Artifact UI")]
    [SerializeField] private Image carriedObjectImage;
    [SerializeField] private Sprite emptySprite; 

    [Header("Pause UI")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject settingPanel;

    private bool isPauseOpen = false;
    private bool isSettingOpen = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        EventManager.SetFade?.Invoke(false);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingOpen)
                ButtonSettingMenu();
            else
                ButtonPauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.R) && isPauseOpen)
            ButtonRestartLevel();
    }

    public void SetCarriedObjectImage(Sprite sprite)
    {
        carriedObjectImage.sprite = sprite ?? emptySprite;
    }

    #region Pause Menu UI

    public void ButtonRestartLevel()
    {
        EventManager.OnRestartLevel?.Invoke();
    }

    public void ButtonBackToMainMenu()
    {
        EventManager.OnExitLevel?.Invoke();
    }

    public void ButtonPauseMenu()
    {
        isPauseOpen = !isPauseOpen;
        pauseMenuPanel.SetActive(isPauseOpen);
        EventManager.OnGamePause?.Invoke(isPauseOpen);
    }

    public void ButtonSettingMenu()
    {
        isSettingOpen = !isSettingOpen;
        settingPanel.SetActive(isSettingOpen);
        pauseMenuPanel.SetActive(!isSettingOpen && isPauseOpen);
    }

    #endregion
}