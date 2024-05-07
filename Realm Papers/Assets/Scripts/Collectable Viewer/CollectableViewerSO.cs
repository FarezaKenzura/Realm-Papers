using UnityEngine;

namespace Freshman.UI.Collectable
{
    [CreateAssetMenu(fileName = "CollectableViewerSO", menuName = "CollectableViewerSO", order = 0)]
    public class CollectableViewerSO : ScriptableObject 
    {
        public Sprite collectableCard;
        public string subjectText;

        [TextArea(3, 10)]
        public string messageText;
        public string sincerelyText;
    }
}