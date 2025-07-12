using UnityEngine;

namespace SnakeGame
{
    public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
    {
        [SerializeField] private ScoreUI m_scoreUI;
        private int m_score;

        public int Score => m_score;
        
        public void AddScore(int score)
        {
            m_score += score;
            m_scoreUI.UpdateScoreUI();
        }
    }
}
