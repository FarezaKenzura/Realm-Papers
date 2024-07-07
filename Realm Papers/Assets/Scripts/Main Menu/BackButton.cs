using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [Header("Back Button")]
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject mainMenuPanel;
    
    public void Start()
    { 
        backButton.onClick.AddListener(Back);
    }

    public void Back()
    {
        panel.SetActive(false);
        mainMenuPanel.SetActive(true);
        AudioManager.Instance.PlaySFX("Tap");
        EventManager.OnMainMenuActive?.Invoke();
    }
}
