using UnityEngine;

public class InteractableObject : MonoBehaviour 
{
    public bool IsPickedUp { get; private set; } = false;

    public void PickUp()
    {
        IsPickedUp = true;
        gameObject.SetActive(false); // Nonaktifkan objek di scene
    }

    public void Drop(Vector3 dropPosition)
    {
        IsPickedUp = false;
        transform.position = dropPosition;
        gameObject.SetActive(true); // Aktifkan kembali objek di scene
    }

    public void Teleport(Vector3 destination)
    {
        transform.position = destination;
        gameObject.SetActive(true); // Aktifkan kembali objek di tempat tujuan
    }
}