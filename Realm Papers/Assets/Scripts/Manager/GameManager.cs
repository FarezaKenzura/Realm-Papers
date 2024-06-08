using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.System.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private GameState currentState;

        public GameState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                OnGameStateChange?.Invoke(currentState);
            }
        }

        public delegate void GameStateChange(GameState newState);
        public event GameStateChange OnGameStateChange;

        private void Awake()
        {
            // Implementasi pola singleton
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}
