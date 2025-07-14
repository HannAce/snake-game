using SnakeGame;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private PlayerMovement m_playerMovement;

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
