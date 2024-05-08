using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealms.UI.Collectable
{
    public class CollectableDescription : MonoBehaviour 
    {
        [Header("UI Component")]
        [SerializeField] private Image cardImage;
        [SerializeField] private TMP_Text subjectMessage;
        [SerializeField] private TMP_Text descriptionMessage;
        [SerializeField] private TMP_Text sincerelyMessage;

        // Mengatur ulang deskripsi menjadi default
        public void ResetDescription() 
        {
            cardImage.gameObject.SetActive(false);
            subjectMessage.text = "";
            descriptionMessage.text = "";
            sincerelyMessage.text = "";
        }

        // Menetapkan deskripsi Collectable
        public void SetDescription(Sprite sprite, string messageSubject, string messageDescription, string messageSincerely) 
        {
            cardImage.gameObject.SetActive(true);
            cardImage.sprite = sprite;
            subjectMessage.text = messageSubject;
            descriptionMessage.text = messageDescription;
            sincerelyMessage.text = messageSincerely;
        }
    }
}
