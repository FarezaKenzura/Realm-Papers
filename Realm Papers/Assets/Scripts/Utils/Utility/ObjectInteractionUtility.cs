using UnityEngine;

public static class ObjectInteractionUtility
{
    public static InteractableObject TryPickupObject(Transform playerTransform, float interactDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerTransform.position, Vector2.right * playerTransform.localScale.x, interactDistance);
        if (hit.collider != null)
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null && !interactableObject.IsPickedUp)
            {
                interactableObject.PickUp();
                return interactableObject;
            }
        }
        return null;
    }

    public static void DropObject(InteractableObject carriedObject, Vector3 dropPosition)
    {
        if (carriedObject != null)
        {
            carriedObject.Drop(dropPosition);
        }
    }

    public static void TeleportObject(InteractableObject carriedObject, Vector3 destination)
    {
        if (carriedObject != null)
        {
            carriedObject.Teleport(destination);
        }
    }
}