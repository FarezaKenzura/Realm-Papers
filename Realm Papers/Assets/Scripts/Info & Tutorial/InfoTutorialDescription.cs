using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Freshman.UI.InfoTutorial
{
    public class InfoTutorialDescription : MonoBehaviour 
    {
        [Header("UI Component")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private TMP_Text subjectInfo;
        [SerializeField] private TMP_Text tutorialInfo;

        // Mengatur ulang deskripsi menjadi default
        public void ResetDescription() 
        {
            backgroundImage.gameObject.SetActive(false);
            subjectInfo.text = "";
            tutorialInfo.text = "";
        }

        // Menetapkan deskripsi Info & Tutorial
        public void SetDescription(Sprite sprite, string infoSubject, string InfoTutorial) 
        {
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = sprite;
            subjectInfo.text = infoSubject;
            tutorialInfo.text = InfoTutorial;
        }
    }
}
