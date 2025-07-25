using System.Collections;
using UnityEngine;

namespace SnakeGame
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private GameObject[] m_foodPrefab;
        [SerializeField] private SnakeSegmentManager m_snakeSegmentManager;
        //private float m_foodSpawnDelay = 1f;
        private Vector2 m_borderedSpawnBoundaryMin = new(-15, -8);
        private Vector2 m_borderedSpawnBoundaryMax = new(15, 7);
        private Vector2 m_unborderedSpawnBoundaryMin = new(-17, -9);
        private Vector2 m_unborderedSpawnBoundaryMax = new(17, 10);
        
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
                int randomX;
                int randomY;
                
                if (GameManager.IsUnborderedMode)
                {
                    randomX = (int)Random.Range(m_unborderedSpawnBoundaryMin.x, m_unborderedSpawnBoundaryMax.x);
                    randomY = (int)Random.Range(m_unborderedSpawnBoundaryMin.y, m_unborderedSpawnBoundaryMax.y);
                }
                else
                {
                    randomX = (int)Random.Range(m_borderedSpawnBoundaryMin.x, m_borderedSpawnBoundaryMax.x);
                    randomY = (int)Random.Range(m_borderedSpawnBoundaryMin.y, m_borderedSpawnBoundaryMax.y);
                }
                
                Vector2 randomSpawnPosition = new Vector2(randomX, randomY);

                if (m_snakeSegmentManager.CheckPositionIsFree(randomSpawnPosition))
                {
                    Instantiate(m_foodPrefab[Random.Range(0, m_foodPrefab.Length)], randomSpawnPosition, Quaternion.identity);
                    return;
                }
            }
        }
    }
}
