using Unity.VisualScripting;
using UnityEngine;

namespace SnakeGame
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private int m_scoreValue = 10;
        private SpawnManager m_spawnManager;
        private ScoreManager m_scoreManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_spawnManager = SpawnManager.Instance;
            m_scoreManager = ScoreManager.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            m_scoreManager.AddScore(m_scoreValue);
            Destroy(this.gameObject);
            m_spawnManager.SpawnFood();
        }
    }
}
