using UnityEngine;

namespace Freshman.UI.InfoTutorial
{
    [CreateAssetMenu(fileName = "InfoTutorialSO", menuName = "InfoTutorialSO", order = 0)]
    public class InfoTutorialSO : ScriptableObject 
    {
        public Sprite backgroundInfo;
        public string subjectText;

        [TextArea(3, 10)]
        public string tutorialText;
    }
}