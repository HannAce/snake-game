using System.Collections;
using UnityEngine;

namespace SnakeGame
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private GameObject m_foodPrefab;
        [SerializeField] private GameObject m_foodContainer;
        private float m_foodSpawnDelay = 1f;
        private int m_xSpawnBoundaryMin = -15;
        private int m_xSpawnBoundaryMax = 15;
        private int m_ySpawnBoundaryMin = -8;
        private int m_ySpawnBoundaryMax = 7;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SpawnFood();
            //StartCoroutine(nameof(SpawnFoodRoutine));
        }

        // Update is called once per frame
        void Update()
        {

        }

        // IEnumerator SpawnFoodRoutine()
        // {
        //     SpawnFood();
        //     yield return new WaitForSeconds(m_foodSpawnDelay);
        //     StartCoroutine(nameof(SpawnFoodRoutine));
        // }

        public void SpawnFood()
        {
            Vector2 randomSpawnPosition = new Vector2(Random.Range(m_xSpawnBoundaryMin, m_xSpawnBoundaryMax), Random.Range(m_ySpawnBoundaryMin, m_ySpawnBoundaryMax));
            
            GameObject newFood = Instantiate(m_foodPrefab, randomSpawnPosition, Quaternion.identity);   
            newFood.transform.SetParent(m_foodContainer.transform);
        }
    }
}
