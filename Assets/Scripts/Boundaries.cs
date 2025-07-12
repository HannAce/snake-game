using System;
using UnityEngine;

namespace SnakeGame
{
    public class Boundaries : MonoBehaviour
    {
        private GameManager m_gameManager;

        private void Start()
        {
            m_gameManager = GameManager.Instance;
        }

        // Checks if collision is with player
        // If so, calls GameOver from Game Manager to stop the game
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                m_gameManager.GameOver();
            }
        }
    }
}
