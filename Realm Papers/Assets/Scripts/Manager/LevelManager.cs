using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperRealm.System.Level
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        
        private void Awake()
        {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);

            EventManager.OnNextLevel += NextLevel;
            EventManager.OnRestartLevel += RestartLevel;
            EventManager.OnExitLevel += ExitLevel;
        }

        private void OnDestroy()
        {
            EventManager.OnNextLevel -= NextLevel;
            EventManager.OnRestartLevel -= RestartLevel;
            EventManager.OnExitLevel -= ExitLevel;
        }

        private void NextLevel()
        {
            EventManager.SetFade?.Invoke(true);

            print("Next Level");

            LeanTween.delayedCall(1.5f, () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
        }

        private void ExitLevel()
        {
            EventManager.SetFade?.Invoke(true);

            print("Back To Main Menu");

            LeanTween.delayedCall(1.5f, () =>
            {
                SceneManager.LoadScene(0);
            });
        }

        private void RestartLevel()
        {
            EventManager.SetFade?.Invoke(true);

            print("Restart Level");

            LeanTween.delayedCall(1.5f, () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            
        }
    }
}
