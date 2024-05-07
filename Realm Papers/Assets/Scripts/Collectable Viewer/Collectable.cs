using UnityEngine;

namespace Freshman.UI.Collectable
{
    public class Collectable : MonoBehaviour 
    {
        // Mengambil referensi ke UI Collectable Description
        [SerializeField] private CollectableDescription collectableDescription;
        // Data collectable
        [SerializeField] private CollectableViewerSO collectableData;

        // Fungsi ini dipanggil saat pemain berinteraksi dengan collectable
        public void ShowCollectableDescription()
        {
            // Menampilkan deskripsi collectable ke UI
            collectableDescription.SetDescription(collectableData.collectableCard, collectableData.subjectText, collectableData.messageText, collectableData.sincerelyText);
        }
    }
}
