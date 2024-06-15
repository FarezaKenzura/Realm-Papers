using System.Collections;
using System.Collections.Generic;
using PaperRealms.UI.Dialogue;
using UnityEngine;

namespace PaperRealm.System.Sequence
{
    public class CutsceneSequence : MonoBehaviour
    {
        [SerializeField] private GameObject DialogueCanvas;

        [SerializeField] private DialogueSO dialogue;

        private void Awake()
        {
            EventManager.OnDialogueEnd += ChangeSequence;
        }

        private void OnDestroy()
        {
            EventManager.OnDialogueEnd -= ChangeSequence;
        }

        private void Start()
        {
            LeanTween.delayedCall(1f, () =>
            {
                EventManager.SetFade?.Invoke(false);
                DialogueCanvas.SetActive(true);
                EventManager.OnDialogueStart?.Invoke(dialogue);
            });
        }

        private void ChangeSequence()
        {
            LeanTween.delayedCall(1f, () =>
            {
                EventManager.SetFade?.Invoke(true);
                LeanTween.delayedCall(1.5f, () =>
                {
                    EventManager.OnNextLevel?.Invoke();
                });
            });

        }
    }
}
