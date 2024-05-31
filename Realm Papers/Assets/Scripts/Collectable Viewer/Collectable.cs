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
            if(!IsInitialized)
                ShowCollectableDescription();
        }

        // Fungsi ini dipanggil saat pemain berinteraksi dengan collectable
        public void ShowCollectableDescription()
        {
            // Menampilkan deskripsi collectable ke UI
            collectableDescription.SetDescription(
                collectableData.collectableCard, collectableData.subjectText, collectableData.messageText, collectableData.sincerelyText
                );
        }
    }
}
