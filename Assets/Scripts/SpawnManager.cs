using System.Collections;
using UnityEngine;

namespace SnakeGame
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private GameObject m_foodPrefab;
        [SerializeField] private GameObject m_foodContainer;
        private float m_foodSpawnDelay = 1f;
        private float m_xSpawnBoundary = 17f;
        private float m_ySpawnBoundary = 9.25f;
        
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
            Vector3 randomSpawnPosition = new Vector2(Random.Range(-m_xSpawnBoundary, m_xSpawnBoundary), Random.Range(-m_ySpawnBoundary, m_ySpawnBoundary));
            
            GameObject newFood = Instantiate(m_foodPrefab, randomSpawnPosition, Quaternion.identity);   
            newFood.transform.SetParent(m_foodContainer.transform);
        }
    }
}
