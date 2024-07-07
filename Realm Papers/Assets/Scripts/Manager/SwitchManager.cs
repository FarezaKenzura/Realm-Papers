using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaperRealms.System.CharacterMovement;
using UniRx;

namespace PaperRealm.System.SwitchManager
{
    public class SwitchManager : MonoBehaviour
    {
        [SerializeField] private CharacterController2D character1;
        [SerializeField] private CharacterController2D character2;

        [SerializeField] private CharacterInput characterInput1;
        [SerializeField] private CharacterInput characterInput2;
        [SerializeField] private KeyCode switchKey = KeyCode.T;

        private CharacterController2D activeCharacter;
        private CharacterInput activeCharacterInput;

        private void Start()
        {
            // Menetapkan karakter pertama sebagai aktif saat memulai
            activeCharacter = character1;
            activeCharacterInput = characterInput1;
            SetCharacterActive(character1, characterInput1, true);
            SetCharacterActive(character2, characterInput2, false);

            // Mendengarkan input untuk mengganti karakter
            Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(switchKey))
                .Subscribe(_ => SwitchCharacters())
                .AddTo(this);
        }

        private void SwitchCharacters()
        {
            // Menonaktifkan karakter yang aktif dan mengaktifkan yang lainnya
            SetCharacterActive(activeCharacter, activeCharacterInput, false);
            if (activeCharacter == character1)
            {
                activeCharacter = character2;
                activeCharacterInput = characterInput2;
            }
            else
            {
                activeCharacter = character1;
                activeCharacterInput = characterInput1;
            }
            SetCharacterActive(activeCharacter, activeCharacterInput, true);
        }

        private void SetCharacterActive(CharacterController2D character, CharacterInput input, bool isActive)
        {
            // Mengaktifkan atau menonaktifkan karakter dan input
            character.enabled = isActive;
            input.enabled = isActive;
            character.IsActive = isActive;
            character.SetCameraEffect(isActive);
        }
    }
}
