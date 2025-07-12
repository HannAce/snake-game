using SnakeGame;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
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

    // Stops the player movement from PlayerMovement
    public void GameOver()
    {
        if (m_playerMovement != null)
        {
            m_playerMovement.StopMovement();
            Debug.Log("Game Over");
        }
    }
}
