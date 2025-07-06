using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SnakeGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float m_playerSpeed;
        private Vector2 m_movementDirection = Vector2.right;
        private bool m_canMove = true;

        void Start()
        {
            m_canMove = true;
        }
        
        // void Update()
        // {
        //     Move();
        // }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (!m_canMove)
            {
                return;
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                m_movementDirection = Vector2.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_movementDirection = Vector2.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_movementDirection = Vector2.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_movementDirection = Vector2.right;
            }
            
            transform.Translate(m_movementDirection * m_playerSpeed * Time.deltaTime);
            //transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0.0f);
        }

        public void StopMovement()
        {
            m_movementDirection = Vector2.zero;
            m_canMove = false;
            
        }
    }
}
