using Unity.VisualScripting;
using UnityEngine;

namespace SnakeGame
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private AudioClip m_collectFoodSFX;
        [SerializeField] private int m_scoreValue = 10;
        private SpawnManager m_spawnManager;
        private ScoreManager m_scoreManager;
        private AudioManager m_audioManager;
        //private SnakeSegmentManager m_snakeSegments;
        
        void Start()
        {
            m_spawnManager = SpawnManager.Instance;
            m_scoreManager = ScoreManager.Instance;
            m_audioManager = AudioManager.Instance;
        }
        
        /// <summary>
        /// Checks if collision is with player
        /// If so, adds score, destroys collected food and spawns new food
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            m_scoreManager.AddScore(m_scoreValue);
            m_audioManager.InstantiateAndPlayAudio2D(m_collectFoodSFX, AudioType.SFX, true, false, 0.7f);
            Destroy(gameObject);
            m_spawnManager.SpawnFood();
        }
    }
}
