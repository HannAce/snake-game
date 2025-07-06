using System;
using UnityEngine;

namespace SnakeGame
{
    public class Boundaries : MonoBehaviour
    {
        [SerializeField] private PlayerMovement m_playerMovement;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawCube(transform.position, gameObject.transform.localScale);
        // }

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
