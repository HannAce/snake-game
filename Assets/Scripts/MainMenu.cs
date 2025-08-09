using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_mainMenuCanvas;
    [SerializeField] private GameObject m_optionsCanvas;

    private void Start()
    {
        m_mainMenuCanvas.SetActive(true);
        m_optionsCanvas.SetActive(false);
    }

    public void StartButtonBordered()
    {
        SceneManager.LoadScene("SnakeBordered");
    }

    public void StartButtonUnbordered()
    {
        SceneManager.LoadScene("SnakeUnbordered");
    }
    
    public void StartButtonUnborderedHard()
    {
        SceneManager.LoadScene("SnakeUnborderedHard");
    }

    public void OptionsButton()
    {
        m_mainMenuCanvas.SetActive(false);
        m_optionsCanvas.SetActive(true);
    }

    public void BackButton()
    {
        m_mainMenuCanvas.SetActive(true);
        m_optionsCanvas.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
