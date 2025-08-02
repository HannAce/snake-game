using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public class SnakeSegmentManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement m_playerMovement;
        [SerializeField] private Transform m_snakeSegmentPrefab;
        private Queue<GameObject> m_snakeSegments = new();
        private int m_snakeLength = 1;
        private GameManager m_gameManager;

        void Start()
        {
            m_gameManager = GameManager.Instance;
            m_playerMovement.MovedPosition += OnPlayerMoved;
        }

        private void OnDestroy()
        {
            m_playerMovement.MovedPosition -= OnPlayerMoved;
        }

        private void OnPlayerMoved(Vector2 currentGridPosition, Vector2 lastGridPosition)
        {
            AddSnakeSegment(lastGridPosition);
        }

        /// <summary>
        /// Instantiates a new snake segment, adds to queue and then checks the snake length by calling that function
        /// </summary>
        /// <param name="segmentPosition"></param>
        public void AddSnakeSegment(Vector2 segmentPosition)
        {
            Transform newSegment = Instantiate(m_snakeSegmentPrefab, segmentPosition, Quaternion.identity);
            //newSegment.position = m_snakeSegments[m_snakeSegments.Count].position;
            m_snakeSegments.Enqueue(newSegment.gameObject);
            CheckSnakeLength();
        }
        
        /// <summary>
        /// Checks if the length of the snake segment queue is greater than the expected snake length.
        /// Destroys extra snake segment.
        /// </summary>
        private void CheckSnakeLength()
        {
            if (m_snakeSegments.Count > m_snakeLength)
            {
                GameObject segmentToDestroy = m_snakeSegments.Dequeue();
                Destroy(segmentToDestroy);
            }
        }

        public bool CheckPositionIsFree(Vector3 position)
        {
            foreach (GameObject snakeSegment in m_snakeSegments)
            {
                if (snakeSegment.transform.position == position)
                {
                    return false;
                }
            }
            return true;
        }
        
        /// <summary>
        /// Checks if collision is with food or player
        /// If food, adds a segment to grow snake
        /// If player, calls GameOver from Game Manager to stop the game
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Food"))
            {
                m_snakeLength++;
            }

            if (other.CompareTag("Player"))
            {
                m_gameManager.GameOver();
            }
        }
    }
}
