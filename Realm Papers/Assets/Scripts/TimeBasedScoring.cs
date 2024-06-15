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
        [SerializeField] private GameObject scoreBoardPanel;

        public void ShowScoreBoard()
        {
            // Menghentikan timer
            timerManager.StopTimer();

            // Menghitung bintang yang diperoleh
            float timeRemaining = timerManager.GetTimeRemaining();
            int starsAwarded = CalculateStars(timeRemaining);
            
            // Menampilkan score board dengan bintang yang diperoleh
            DisplayStars(starsAwarded);
            scoreBoardPanel.SetActive(true);
        }

        private int CalculateStars(float timeRemaining)
        {
            float timeSpent = 300 - timeRemaining; // 300 detik adalah 5 menit

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
                if (i < starsAwarded)
                {
                    stars[i].sprite = filledStar;
                }
            }
        }
    }
}
