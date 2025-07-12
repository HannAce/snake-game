using System.Collections.Generic;
using SnakeGame;
using UnityEngine;

public class SnakeSegments : MonoBehaviour
{
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] private Transform m_snakeSegmentPrefab;
    [SerializeField] private List<Transform> m_snakeSegments = new();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSnakeSegment()
    {
        Transform newSegment = Instantiate(m_snakeSegmentPrefab);
        //newSegment.position = m_snakeSegments[m_snakeSegments.Count].position;
        //m_snakeSegments.Add(newSegment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            AddSnakeSegment();
        }

        if (other.CompareTag("Player"))
        {
            if (m_playerMovement != null)
            {
                m_playerMovement.StopMovement();
                Debug.Log("Game Over");
            }
        }
    }
}
