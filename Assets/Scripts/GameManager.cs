using System;
using SnakeGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] TMP_Text m_gameOverText;

    private void Start()
    {
        m_gameOverText.enabled = false;
    }

    private void Update()
    {
        RestartGame();
        MainMenu();
    }

    // Stops the player movement from PlayerMovement
    public void GameOver()
    {
        if (m_playerMovement != null)
        {
            m_playerMovement.StopMovement();
            m_gameOverText.enabled = true;
            Debug.Log("Game Over");
        }
    }

    private void RestartGame()
    {
        if (Input.GetKey(KeyCode.R) && m_gameOverText.enabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void MainMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
