using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealms.UI.Dialogue
{
    public class DialogueManager : MonoBehaviour 
    {
        [Header("UI Canvas")] 
        [SerializeField] private CanvasGroup canvasGroupDialog;
        
        [Header("UI Elements")] 
        [SerializeField] private TextMeshProUGUI txtActorName;
        [SerializeField] private TextMeshProUGUI txtDialogue;
        [SerializeField] private Button btnNextDialogue;

        private DialogueSO dialogueData;
        private int dialogueConversationIndex;

        private Vector3 initialPosition;
        private Vector3 offScreenLeftPosition;
        private Vector3 offScreenRightPosition;

        private void Awake()
        {
            initialPosition = canvasGroupDialog.transform.localPosition;
            offScreenLeftPosition = initialPosition + new Vector3(-50, 0, 0);
            offScreenRightPosition = initialPosition + new Vector3(50, 0, 0);

            btnNextDialogue.onClick.AddListener(NextDialogue);
            EventManager.OnDialogueStart += SetUpDialogue;
        }

        private void OnDestroy()
        {
            EventManager.OnDialogueStart -= SetUpDialogue;
        }

        public void SetUpDialogue(DialogueSO data)
        {
            dialogueData = data;
            StartDialogue();
        }

        private void StartDialogue()
        {
            canvasGroupDialog.alpha = 0;
            dialogueConversationIndex = 0;
            canvasGroupDialog.transform.localPosition = offScreenLeftPosition;

            LeanTween.moveLocal(canvasGroupDialog.gameObject, initialPosition, 1f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.alphaCanvas(canvasGroupDialog, 1, 1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                canvasGroupDialog.interactable = true;
                canvasGroupDialog.blocksRaycasts = true;  

                NextDialogue();
            });
        }

        private void NextDialogue()
        {
            btnNextDialogue.interactable = false;
            AudioManager.Instance.PlaySFX("Tap");
            if (dialogueConversationIndex < dialogueData.Data.Length)
            {
                txtActorName.SetText(dialogueData.Data[dialogueConversationIndex].CharacterName);
                StartCoroutine(GeneratingWord());
            }
            else
            {
                EndDialogue();
            }
        }

        IEnumerator GeneratingWord()
        {
            txtDialogue.SetText(dialogueData.Data[dialogueConversationIndex].Dialogue);
            for (int i = 0; i <= dialogueData.Data[dialogueConversationIndex].Dialogue.Length; i++)
            {
                txtDialogue.maxVisibleCharacters = i;
                AudioManager.Instance.PlaySFX("Tap");
                yield return new WaitForSeconds(0.02f);
            }
            btnNextDialogue.interactable = true;
            dialogueConversationIndex++;

            EventManager.OnSentenceDialogueEnd?.Invoke();

            yield return null;
        }

        private void EndDialogue()
        {
            LeanTween.moveLocal(canvasGroupDialog.gameObject, offScreenRightPosition, 1f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.alphaCanvas(canvasGroupDialog, 0, 1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                canvasGroupDialog.interactable = false;
                canvasGroupDialog.blocksRaycasts = false;  

                EventManager.OnDialogueEnd?.Invoke();
            });
        }
    }
}
