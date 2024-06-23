using System.Collections.Generic;
using PaperRealm.System.Timer;
using UnityEngine;

namespace PaperRealm.System.Trigger
{
    public class DoorTrigger : MonoBehaviour 
    {
        [SerializeField] private string characterTag;
        [SerializeField] private TimeBasedScoring timeBasedScoring;

        private static HashSet<GameObject> charactersInTrigger = new HashSet<GameObject>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(characterTag))
            {
                Debug.Log("Character entered: " + other.gameObject.name + " at door: " + gameObject.name);
                charactersInTrigger.Add(other.gameObject);
                Debug.Log("Characters in trigger at door " + gameObject.name + " after enter: " + charactersInTrigger.Count);
                CheckCharacters();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(characterTag))
            {
                Debug.Log("Character exited: " + other.gameObject.name + " at door: " + gameObject.name);
                charactersInTrigger.Remove(other.gameObject);
                Debug.Log("Characters in trigger at door " + gameObject.name + " after exit: " + charactersInTrigger.Count);
            }
        }

        private void CheckCharacters()
        {
            Debug.Log("Checking characters in trigger at door " + gameObject.name + ": " + charactersInTrigger.Count);
            if (charactersInTrigger.Count >= 2)
            {
                Debug.Log("Showing scoreboard at door " + gameObject.name);
                timeBasedScoring.ShowScoreBoard();
            }
        }
    }
}