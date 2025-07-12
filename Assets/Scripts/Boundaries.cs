using System;
using UnityEngine;

namespace SnakeGame
{
    public class Boundaries : MonoBehaviour
    {
        [SerializeField] private PlayerMovement m_playerMovement;

        // Checks if collision is with player
        // If so, calls StopMovement from PlayerMovement
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (m_playerMovement != null)
                {
                    m_playerMovement.StopMovement();
                    Debug.Log("Game Over");
                }
            }
        }
    }
}
