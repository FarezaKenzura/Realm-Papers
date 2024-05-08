using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealms.UI.Dialogue
{
    public class DialogueManager : MonoBehaviour 
    {
        [Header("UI")] 
        [SerializeField] private GameObject _cnvsDialogue;

        [SerializeField] private TextMeshProUGUI _txtDialogue;
        [SerializeField] private TextMeshProUGUI _txtActorName;
        [SerializeField] private DialogueSO _dialogueData;
        [SerializeField] private Button _btnNextDialogue;
        private int _dialogueConversationIndex;

        private void Awake()
        {
            _btnNextDialogue.onClick.AddListener(NextDialogue);

            EventManager.OnDialogueStart += SetUpDialogue;
        }

        private void OnDestroy()
        {
            EventManager.OnDialogueStart -= SetUpDialogue;
        }

        public void SetUpDialogue(DialogueSO data)
        {
            _dialogueData = data;
            StartDialogue();
        }

        private void StartDialogue()
        {
            _cnvsDialogue.SetActive(true);
            _dialogueConversationIndex = 0;
            NextDialogue();

        }

        private void NextDialogue()
        {
            _btnNextDialogue.interactable = false;
            
            if (_dialogueConversationIndex < _dialogueData.Data.Length)
            {
                _txtActorName.SetText(_dialogueData.Data[_dialogueConversationIndex].ActorName);
                StartCoroutine(GeneratingWord());
            }
            else
            {
                EndDialogue();
            }
            
        }

        IEnumerator GeneratingWord()
        {
            _txtDialogue.SetText(_dialogueData.Data[_dialogueConversationIndex].Dialogue);
            for (int i = 0; i <= _dialogueData.Data[_dialogueConversationIndex].Dialogue.Length; i++)
            {
                _txtDialogue.maxVisibleCharacters = i;
                yield return new WaitForSeconds(0.02f);
            }
            _btnNextDialogue.interactable = true;
            _dialogueConversationIndex++;

            EventManager.OnSentenceDialogueEnd?.Invoke();

            yield return null;
        }

        private void EndDialogue()
        {
            EventManager.OnDialogueEnd?.Invoke();
            _cnvsDialogue.SetActive(false);
        }
    }
}
