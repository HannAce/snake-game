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
        
        void Start()
        {
            m_spawnManager = SpawnManager.Instance;
            m_scoreManager = ScoreManager.Instance;
            m_audioManager = AudioManager.Instance;
        }

        /// <summary>
        /// Checks if collision is with player or wall
        /// If player, adds score, destroys collected food and spawns new food
        /// If wall, destroy spawned oob food and spawns new food
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                m_scoreManager.AddScore(m_scoreValue);
                m_audioManager.InstantiateAndPlayAudio2D(m_collectFoodSFX, AudioType.SFX, true, false, 0.7f);
                Destroy(gameObject);
                m_spawnManager.SpawnFood();
            }

            // if (other.CompareTag("Wall"))
            // {
            //     Debug.Log("Food spawned on wall, destroyed.");
            //     Destroy(gameObject);
            //     m_spawnManager.SpawnFood();
            // }
        }

        public bool CheckPositionIsFree(Vector2 position)
        {
            Collider2D colliderInPosition = Physics2D.OverlapCircle(position, 0.2f);
            if (colliderInPosition != null)
            {
                Debug.Log($"Food cannot spawn here due to {colliderInPosition}!");
                return false;
            }
            return true;
        }
    }
}
