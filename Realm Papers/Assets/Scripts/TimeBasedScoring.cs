using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperRealm.System.Timer
{
    public class TimeBasedScoring : MonoBehaviour
    {
        [SerializeField] private TimeManager timerManager;
        [SerializeField] private Image[] stars;
        [SerializeField] private Sprite filledStar;

        [SerializeField] private int loadScene;

        #region Score Star
        public void ShowScoreBoard()
        {
            timerManager.StopTimer();

            float timeRemaining = timerManager.GetTimeRemaining();
            int starsAwarded = CalculateStars(timeRemaining);
            
            DisplayStars(starsAwarded);
            gameObject.SetActive(true);
        }

        private int CalculateStars(float timeRemaining)
        {
            float timeSpent = 300 - timeRemaining;

            if (timeSpent <= 60)
            {
                return 3;
            }
            else if (timeSpent <= 150)
            {
                return 2;
            }
            else if (timeSpent <= 300)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void DisplayStars(int starsAwarded)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].enabled = (i < starsAwarded);
                if (stars[i].enabled)
                {
                    stars[i].sprite = filledStar;
                }
            }
        }
        #endregion

        #region Score Menu
        public void NextLevel()
        {
            EventManager.OnNextLevel?.Invoke(loadScene);
        }

        public void ToMainMenu()
        {
            EventManager.OnExitLevel?.Invoke();
        }
        #endregion
    }
}
