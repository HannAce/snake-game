using System;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
    {
        [SerializeField] private ScoreUI m_scoreUI;
        private int m_score;
        private int m_highScore;

        public int Score => m_score;
        public int HighScore => m_highScore;

        protected override void Awake()
        {
            base.Awake();
            m_highScore = PlayerPrefs.GetInt("HighScore", 0);
        }

        public void AddScore(int score)
        {
            m_score += score;
            m_scoreUI.UpdateScoreUI();
            TrySetHighScore();
        }

        public void TrySetHighScore()
        {
            if (m_highScore >= m_score)
            {
                return;
            }

            m_highScore = m_score;
            m_scoreUI.UpdateHighScoreUI();
            PlayerPrefs.SetInt("HighScore", m_highScore);
        }
    }
}
