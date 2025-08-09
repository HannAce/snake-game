using System;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
    {
        [SerializeField] private GameManager m_gameManager;
        [SerializeField] private ScoreUI m_scoreUI;
        private int m_score;
        private int m_highScore;

        public int Score => m_score;
        public int HighScore => m_highScore;
        
        public static Action<int> ScoreChanged;
        public static Action<int> HighScoreChanged;

        private void Start()
        {
            if (m_gameManager.GetGameMode() == GameMode.Unbordered)
            {
                m_highScore = PlayerPrefs.GetInt("UnborderedHighScore", 0);
            }

            else if (m_gameManager.GetGameMode() == GameMode.UnborderedHard)
            {
                m_highScore = PlayerPrefs.GetInt("UnborderedHardHighScore", 0);
            }
            else
            {
                m_highScore = PlayerPrefs.GetInt("BorderedHighScore", 0);
            }
            
            HighScoreChanged?.Invoke(m_highScore);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                TrySetHighScore(true);
                Debug.Log("<color=yellow>Cheat activated:</color> High Score reset.");
            }
        }

        public void AddScore(int score)
        {
            m_score += score;
            ScoreChanged?.Invoke(m_score);
            TrySetHighScore(false);
        }

        // either force set a score (e.g. back to 0), or continue to set the actual new high score
        public void TrySetHighScore(bool forceScore)
        {
            if (m_highScore >= m_score && !forceScore)
            {
                return;
            }

            m_highScore = m_score;
            
            if (m_gameManager.GetGameMode() == GameMode.Unbordered)
            {
                PlayerPrefs.SetInt("UnborderedHighScore", m_highScore);
            }
            else if (m_gameManager.GetGameMode() == GameMode.UnborderedHard)
            {
                PlayerPrefs.SetInt("UnborderedHardHighScore", m_highScore);
            }
            else
            {
                PlayerPrefs.SetInt("BorderedHighScore", m_highScore);
            }
            
            HighScoreChanged?.Invoke(m_highScore);
        }
    }
}
