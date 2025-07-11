using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SnakeGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float m_playerSpeed;
        private Vector2 m_movementDirection = Vector2.right;
        private Vector2 m_targetPosition;
        private bool m_canMove = true;

        void Start()
        {
            m_canMove = true;
            m_targetPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (!m_canMove)
            {
                return;
            }
            
            GetMovementInput();
            Move();
        }

        private void GetMovementInput()
        {
            // If holding Up and not already going Down
            if (Input.GetKey(KeyCode.W) && m_movementDirection.y >= 0)
            {
                m_movementDirection = Vector2.up;
            }
            // If holding Down and not already going Up
            else if (Input.GetKey(KeyCode.S) && m_movementDirection.y <= 0)
            {
                m_movementDirection = Vector2.down;
            }
            // If holding Left and not already going Right
            else if (Input.GetKey(KeyCode.A) && m_movementDirection.x <= 0)
            {
                m_movementDirection = Vector2.left;
            }
            // If holding Right and not already going Left
            else if (Input.GetKey(KeyCode.D) && m_movementDirection.x >= 0)
            {
                m_movementDirection = Vector2.right;
            }
        }

        private void Move()
        {
            // Target direction is the input for the direction player is moving
            Vector2 targetDirection = m_movementDirection * (m_playerSpeed * Time.deltaTime);
            
            // Adding target direction to target position to move towards that position
            // Alternative to transform.Translate for movement
            m_targetPosition += targetDirection;
            
            // m_targetPosition above is smooth movement, like a ghost player.
            // We will round to next int and snap to grid position before moving actual player
            Vector2 gridPosition = new Vector2(Mathf.Round(m_targetPosition.x), Mathf.Round(m_targetPosition.y));
            transform.position = gridPosition;
        }
        
        public void StopMovement()
        {
            m_movementDirection = Vector2.zero;
            m_canMove = false;
        }

         
        private void OnDrawGizmos()
        {
            // Draws a gizmo to represent the ghost player/target position
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(m_targetPosition, 0.5f);
        }
    }
}
