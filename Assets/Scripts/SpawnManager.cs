using System.Collections;
using UnityEngine;

namespace SnakeGame
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private GameObject[] m_foodPrefab;
        [SerializeField] private SnakeSegmentManager m_snakeSegmentManager;
        private float m_foodSpawnDelay = 1f;
        private int m_xSpawnBoundaryMin = -15;
        private int m_xSpawnBoundaryMax = 15;
        private int m_ySpawnBoundaryMin = -8;
        private int m_ySpawnBoundaryMax = 7;
        
        void Start()
        {
            SpawnFood();
        }

        // Alternative for food to spawn after an amount of time instead of when one is collected, decided not to use
        // IEnumerator SpawnFoodRoutine()
        // {
        //     SpawnFood();
        //     yield return new WaitForSeconds(m_foodSpawnDelay);
        //     StartCoroutine(nameof(SpawnFoodRoutine));
        // }

        public void SpawnFood()
        {
            // Check up to 100 times for a free position in case a snake segment is in the way
            // return if free position is found and spawn food
            for (int i = 0; i < 100; i++)
            {
                Vector2 randomSpawnPosition = new Vector2(Random.Range(m_xSpawnBoundaryMin, m_xSpawnBoundaryMax), Random.Range(m_ySpawnBoundaryMin, m_ySpawnBoundaryMax));

                if (m_snakeSegmentManager.CheckPositionIsFree(randomSpawnPosition))
                {
                    Instantiate(m_foodPrefab[Random.Range(0, m_foodPrefab.Length)], randomSpawnPosition, Quaternion.identity);
                    return;
                }
            }
        }
    }
}
