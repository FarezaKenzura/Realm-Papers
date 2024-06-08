using PaperRealm.System.GameManager;
using UnityEngine;

namespace PaperRealms.UI.Collectable
{
    public class Collectable : MonoBehaviour, IInteractable 
    {
        // Mengambil referensi ke UI Collectable Description
        [SerializeField] private CollectableDescription collectableDescription;
        // Data collectable
        [SerializeField] private CollectableViewerSO collectableData;

        public bool IsInitialized => false;

        public void Interact()
        {
            if (!collectableDescription.IsVisible && !IsInitialized)
                ShowCollectableDescription();
        }

        public void ShowCollectableDescription()
        {
            collectableDescription.OpenCollectable();
            collectableDescription.SetDescription(
                collectableData.collectableCard, 
                collectableData.subjectText, 
                collectableData.messageText, 
                collectableData.sincerelyText
            );
        }
    }
}
