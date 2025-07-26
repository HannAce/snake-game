using System;
using SnakeGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioType = SnakeGame.AudioType;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private AudioManager m_audioManager;
    [SerializeField] private AudioClip m_backgroundMusic;
    [SerializeField] private TMP_Text m_gameOverText;
    [SerializeField] private AudioClip m_gameOverSFX;
    public static bool IsUnborderedMode;

    public static Action GameEnded;

    protected override void Awake()
    {
        base.Awake();
        
        // Sets unbordered mode to true if unbordered scene is active
        IsUnborderedMode = SceneManager.GetActiveScene().name == "SnakeUnbordered";
    }

    private void Start()
    {
        m_audioManager = AudioManager.Instance;
        
        m_gameOverText.enabled = false;
        
        m_audioManager.InstantiateAndPlayAudio2D(m_backgroundMusic, AudioType.Music, false, true, 0.8f);
    }

    private void Update()
    {
        RestartGame();
        MainMenu();
    }

    // Stops the player movement from PlayerMovement
    public void GameOver()
    {
        GameEnded?.Invoke();
        m_gameOverText.enabled = true;
        m_audioManager.InstantiateAndPlayAudio2D(m_gameOverSFX, AudioType.SFX, true, false, 0.7f);
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
