using PaperRealms.System.CharacterMovement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController2D playerController = other.GetComponent<CharacterController2D>();
            if (playerController != null)
            {
                playerController.Teleport(teleportPoint.position);
            }
        }
    }
}