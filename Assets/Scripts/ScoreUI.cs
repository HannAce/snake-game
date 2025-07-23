using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace SnakeGame
{
    public class ScoreUI : MonoBehaviourSingleton<ScoreUI>
    {
        [SerializeField] private TMP_Text m_scoreText;
        [SerializeField] private TMP_Text m_highScoreText;
        private ScoreManager m_scoreManager;

        void Start()
        {
            m_scoreManager = ScoreManager.Instance;

            m_scoreText.text = "Score: 0";
            m_highScoreText.text = $"High Score: {m_scoreManager.HighScore.ToString()}";
        }

        public void UpdateScoreUI()
        {
            m_scoreText.text = $"Score: {m_scoreManager.Score}";
        }

        public void UpdateHighScoreUI()
        {
            m_highScoreText.text = $"High Score: {m_scoreManager.HighScore.ToString()}";
        }
    }
}
