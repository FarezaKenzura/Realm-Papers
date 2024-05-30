using UnityEngine;

public class Mechanism : MonoBehaviour, IInteractable 
{
    [Header("Platform Reference")]
    [Tooltip("Referensi ke objek platform yang akan digerakkan.")]
    [SerializeField] private Platform platformToMove;

    /// <summary>
    /// Apakah mekanisme telah diaktifkan.
    /// </summary>
    public bool IsActivated => false;

    /// <summary>
    /// Menginteraksi dengan mekanisme.
    /// </summary>
    public void Interact()
    {
        if(!IsActivated)
        {
            // Jika platform berada di posisi awal, gerakkan ke atas
            if (platformToMove.transform.position == platformToMove.GetInitialPosition())
            {
                platformToMove.MovePlatformUp();
            }
            else // Jika platform sudah berada di atas, gerakkan ke bawah
            {
                platformToMove.MovePlatformDown();
            }
        }
    }
}