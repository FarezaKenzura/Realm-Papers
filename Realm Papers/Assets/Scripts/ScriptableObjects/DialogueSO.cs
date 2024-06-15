using System;
using UnityEngine;

namespace PaperRealms.UI.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueSO", menuName = "DialogueSO", order = 0)]
    public class DialogueSO : ScriptableObject 
    {
        public DialogueData[] Data;
    }

    [Serializable]
    public class DialogueData
    {
        public string CharacterName;
        public CharacterType Type;
        [TextArea(15,20)]
        public string Dialogue;
        
    }

    public enum CharacterType
    {
        Player1,
        Player2,
        NPC
    }
}
