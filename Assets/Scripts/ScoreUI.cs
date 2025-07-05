using TMPro;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreUI : MonoBehaviourSingleton<ScoreUI>
    {
        [SerializeField] private TMP_Text m_ScoreText;
        private ScoreManager m_scoreManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
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
