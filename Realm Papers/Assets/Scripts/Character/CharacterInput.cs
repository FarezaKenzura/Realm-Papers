using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private float interactRadius;
    [SerializeField] private List<InteractPopupData> interactPopupDataList;
    [SerializeField] private Vector3 popupOffset;

    private GameObject currentInteractPopup;

    private void Update()
    {
        HandleInteractables();
        UpdatePopupPosition();
    }

    private void HandleInteractables()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        bool interactableFound = false;

        foreach (Collider2D col in colliders)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable == null) continue;

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
            currentInteractPopup = Instantiate(interactPopupPrefab, transform.position + popupOffset, Quaternion.identity);
            currentInteractPopup.transform.localScale = Vector3.zero;
            LeanTween.scale(currentInteractPopup, Vector3.one, 0.5f).setEase(LeanTweenType.easeInOutQuart);
        }
        else
        {
            currentInteractPopup.transform.position = transform.position + popupOffset;
        }
    }

    private void HideInteractPopup()
    {
        if (currentInteractPopup != null)
        {
            GameObject popupToDestroy = currentInteractPopup;
            currentInteractPopup = null;

            LeanTween.scale(popupToDestroy, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutQuart).setOnComplete(() =>
            {
                Destroy(popupToDestroy);
            }).setOnUpdate((float val) =>
            {
                if (popupToDestroy != null)
                {
                    popupToDestroy.transform.position = transform.position + popupOffset;
                }
            });
        }
    }

    private void UpdatePopupPosition()
    {
        if (currentInteractPopup != null)
        {
            currentInteractPopup.transform.position = transform.position + popupOffset;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        GizmosExtension.DrawWireCircle(transform.position, interactRadius);
    }
}
