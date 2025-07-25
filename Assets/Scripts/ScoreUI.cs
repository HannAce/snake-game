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

        protected override void Awake()
        {
            base.Awake();

            ScoreManager.ScoreChanged += OnScoreChanged;
            ScoreManager.HighScoreChanged += OnHighScoreChanged;
        }

        void Start()
        {
            m_scoreManager = ScoreManager.Instance;

            m_scoreText.text = "Score: 0";
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            ScoreManager.ScoreChanged -= OnScoreChanged;
            ScoreManager.HighScoreChanged -= OnHighScoreChanged;
        }

        public void OnScoreChanged(int score)
        {
            m_scoreText.text = $"Score: {score.ToString()}";
        }

        public void OnHighScoreChanged(int highScore)
        {
            m_highScoreText.text = $"High Score: {highScore.ToString()}";
        }
    }
}
