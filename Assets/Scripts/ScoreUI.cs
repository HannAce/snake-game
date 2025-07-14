using TMPro;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreUI : MonoBehaviourSingleton<ScoreUI>
    {
        [SerializeField] private TMP_Text m_ScoreText;
        private ScoreManager m_scoreManager;

        void Start()
        {
            m_scoreManager = ScoreManager.Instance;

            m_ScoreText.text = "Score: 0";
        }

        public void UpdateScoreUI()
        {
            m_ScoreText.text = $"Score: {m_scoreManager.Score}";
        }
    }
}
