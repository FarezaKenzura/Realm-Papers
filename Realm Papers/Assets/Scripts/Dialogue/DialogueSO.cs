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
        public string ActorName;
        public ActorType Type;
        [TextArea(15,20)]
        public string Dialogue;
        
    }

    public enum ActorType
    {
        Player,
        NPC
    }
}
