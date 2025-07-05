using UnityEngine;

namespace SnakeGame
{
    public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
    {
        [SerializeField] private ScoreUI m_scoreUI;
        private int m_score;

        public int Score => m_score;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int score)
        {
            m_score += score;
            m_scoreUI.UpdateScoreUI();
            Debug.Log(m_score);
        }
    }
}
