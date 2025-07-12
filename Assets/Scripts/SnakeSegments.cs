using System.Collections.Generic;
using SnakeGame;
using UnityEngine;

public class SnakeSegments : MonoBehaviour
{
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] private Transform m_snakeSegmentPrefab;
    [SerializeField] private List<Transform> m_snakeSegments = new();
    private GameManager m_gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gameManager = GameManager.Instance;
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

    // Checks if collision is with food or player
    // If food, adds a segment to grow snake
    // If player, calls GameOver from Game Manager to stop the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            AddSnakeSegment();
        }

        if (other.CompareTag("Player"))
        {
            m_gameManager.GameOver();
        }
    }
}
