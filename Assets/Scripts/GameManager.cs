using SnakeGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioType = SnakeGame.AudioType;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private AudioManager m_audioManager;
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] private TMP_Text m_gameOverText;
    [SerializeField] private AudioClip m_gameOverSFX;

    private void Start()
    {
        m_audioManager = AudioManager.Instance;
        
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
            m_audioManager.InstantiateAndPlayAudio2D(m_gameOverSFX, AudioType.SFX, true, false, 0.7f);
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
