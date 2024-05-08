using System;
using UnityEngine;

namespace PaperRealms.UI.InfoTutorial
{
    [CreateAssetMenu(fileName = "InfoTutorialSO", menuName = "InfoTutorialSO", order = 0)]
    public class InfoTutorialSO : ScriptableObject 
    {
        public TutorialData[] Data;
    }

    [Serializable]
    public class TutorialData
    {
        public Sprite backgroundInfo;
        public string subjectText;

        [TextArea(3, 10)]
        public string tutorialText;
    }
}