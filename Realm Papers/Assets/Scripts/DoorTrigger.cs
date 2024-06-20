using System.Collections.Generic;
using PaperRealm.System.Timer;
using UnityEngine;

namespace PaperRealm.System.Trigger
{
    public class DoorTrigger : MonoBehaviour 
    {
        [SerializeField] private string characterTag = "Character";
        [SerializeField] private TimeBasedScoring timeBasedScoring;

        private HashSet<GameObject> charactersInTrigger = new HashSet<GameObject>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(characterTag))
            {
                charactersInTrigger.Add(other.gameObject);
                CheckCharacters();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(characterTag))
            {
                charactersInTrigger.Remove(other.gameObject);
            }
        }

        private void CheckCharacters()
        {
            if (charactersInTrigger.Count >= 2)
            {
                timeBasedScoring.ShowScoreBoard();
            }
        }
    }
}