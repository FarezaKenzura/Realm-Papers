using UnityEngine;

[CreateAssetMenu(fileName = "InteractPopupData", menuName = "Interact System/Interact Popup Data")]
public class InteractPopupData : ScriptableObject
{
    public GameObject interactPopupPrefab;
    public LayerMask objectLayer;
}