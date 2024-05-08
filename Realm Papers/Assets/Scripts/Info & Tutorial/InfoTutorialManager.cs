using TMPro;
using UnityEngine;
using UnityEngine.UI;

using PaperRealms.UI.InfoTutorial;

public class InfoTutorialManager : MonoBehaviour 
{
    [Header("Tutorial Data")]
    [SerializeField] private InfoTutorialSO tutorialData;

    [Header("UI")]
    [SerializeField] private GameObject cnvsTutorial;
    [SerializeField] private TextMeshProUGUI txtContent;
    [SerializeField] private TextMeshProUGUI subjectContent;
    [SerializeField] private Image imgTutorial;
    [SerializeField] private Button btnNext;

    private int index;

    private void Awake()
    {
        btnNext.onClick.AddListener(NextTutorial);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpTutorial();
    }

    private void SetUpTutorial()
    {
        cnvsTutorial.SetActive(true);
        index = 0;
        NextTutorial();
    }

    private void NextTutorial()
    {
        if (index < tutorialData.Data.Length)
        {
            imgTutorial.sprite = tutorialData.Data[index].backgroundInfo;
            subjectContent.SetText(tutorialData.Data[index].subjectText);
            txtContent.SetText(tutorialData.Data[index].tutorialText);
            index++;
        }
        else
        {
            EndTutorial();
        }
        
    }

    private void EndTutorial()
    {
        cnvsTutorial.SetActive(false);
    }
}