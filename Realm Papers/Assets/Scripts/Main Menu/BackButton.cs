using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [Header("Back Button")]
    public Button backButton;
    public GameObject panel;
    
    public void Start()
    { 
        backButton.onClick.AddListener(Back);
    }

    public void Back()
    {
        panel.SetActive(false);
        
        AudioManager.instance.PlaySFX("Klik Button");
    }
}
