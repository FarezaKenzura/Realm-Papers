using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float interactRadius;
    public List<InteractPopupData> interactPopupDataList;

    private GameObject currentInteractPopup;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius);

        bool interactableFound = false;

        foreach (Collider2D col in colliders)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable == null || interactable.IsActivated) continue;

            foreach (InteractPopupData popupData in interactPopupDataList)
            {
                if (((1 << col.gameObject.layer) & popupData.objectLayer) == 0) continue;

                ShowInteractPopup(popupData.interactPopupPrefab);
                interactableFound = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    interactable.Interact();
                }

                break;
            }

            if (interactableFound) break;
        }

        if (!interactableFound) HideInteractPopup();
    }

    private void ShowInteractPopup(GameObject interactPopupPrefab)
    {
        if (currentInteractPopup == null)
        {
            currentInteractPopup = Instantiate(interactPopupPrefab, transform.position, Quaternion.identity);
        }
    }

    private void HideInteractPopup()
    {
        if (currentInteractPopup != null)
        {
            Destroy(currentInteractPopup);
            currentInteractPopup = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        GizmosExtension.DrawWireCircle(transform.position, interactRadius);
    }
}
