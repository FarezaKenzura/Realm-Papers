using TMPro;
using UnityEngine;
using UnityEngine.UI;

using PaperRealms.UI.InfoTutorial;
using PaperRealm.System.GameManager;

public class InfoTutorialManager : MonoBehaviour 
{
    [Header("Tutorial UI")]
    [SerializeField] private RectTransform tutorialPanel;

    [Header("Tutorial Data")]
    [SerializeField] private InfoTutorialSO tutorialData;

    [Header("Tutorial UI Components")]
    [SerializeField] private TextMeshProUGUI txtContent;
    [SerializeField] private TextMeshProUGUI subjectContent;
    [SerializeField] private Image imgTutorial;
    [SerializeField] private Button btnNext;

    private int index;

    private void Awake()
    {
        btnNext.onClick.AddListener(NextTutorial);
    }

    void Start()
    {
        SetUpTutorial();
    }

    private void SetUpTutorial()
    {
        tutorialPanel.anchoredPosition = new Vector2(-Screen.width, Screen.height);
        LeanTween.move(tutorialPanel, Vector2.zero, 0.5f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => 
            {
                tutorialPanel.GetComponent<Image>().enabled = true;
            });

        tutorialPanel.gameObject.SetActive(true);
        UpdateTutorialContent();
        GameManager.Instance.CurrentState = GameState.Tutorial;
    }

    private void NextTutorial()
    {
        if (index < tutorialData.Data.Length - 1)
        {
            index++;
            UpdateTutorialContent();
        }
        else
        {
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        tutorialPanel.GetComponent<Image>().enabled = false;

        // Move to bottom right
        LeanTween.move(tutorialPanel, new Vector2(Screen.width, -Screen.height), 0.5f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                GameManager.Instance.CurrentState = GameState.GamePlay;
                tutorialPanel.gameObject.SetActive(false);
            });
    }

    private void UpdateTutorialContent()
    {
        imgTutorial.sprite = tutorialData.Data[index].backgroundInfo;
        subjectContent.SetText(tutorialData.Data[index].subjectText);
        txtContent.SetText(tutorialData.Data[index].tutorialText);
    }
}