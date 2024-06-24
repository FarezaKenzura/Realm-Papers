using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PaperRealm.System.Timer
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private float startTime;
        private float timeRemaining;
        private bool timerIsRunning = false;

        private void Start()
        {
            StartTimer(startTime);
        }

        public void StartTimer(float timeToCount)
        {
            timeRemaining = timeToCount;
            timerIsRunning = true;
        }

        private void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    DisplayTime(timeRemaining);
                }
            }
        }

        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void StopTimer()
        {
            timerIsRunning = false;
        }

        public float GetTimeRemaining()
        {
            return timeRemaining;
        }
    }
}
