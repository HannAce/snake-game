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
        private Vector2? m_lastGridPosition; // ? means this variable can potentially = null
        private bool m_canMove = true;

        public Action<Vector2, Vector2> MovedPosition;

        void Start()
        {
            m_canMove = true;
            m_targetPosition = transform.position;
            m_lastGridPosition = null; // set to null at start of game, player has no last position yet
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
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && m_movementDirection.y >= 0)
            {
                m_movementDirection = Vector2.up;
            }
            // If holding Down and not already going Up
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && m_movementDirection.y <= 0)
            {
                m_movementDirection = Vector2.down;
            }
            // If holding Left and not already going Right
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && m_movementDirection.x <= 0)
            {
                m_movementDirection = Vector2.left;
            }
            // If holding Right and not already going Left
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && m_movementDirection.x >= 0)
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
            // This will round to next int and snap to grid position before moving actual player
            Vector2 gridPosition = new Vector2(Mathf.Round(m_targetPosition.x), Mathf.Round(m_targetPosition.y));
            transform.position = gridPosition;

            // Checks if the last grid position has a value and isn't null
            if (gridPosition != m_lastGridPosition && m_lastGridPosition.HasValue)
            {
                MovedPosition?.Invoke(gridPosition, m_lastGridPosition.Value);
            }
            m_lastGridPosition = gridPosition;
        }
        
        // This is called if the player collides with a wall to stop movement
        // TODO Also maybe needed when player collides with self after segment implementation 
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
