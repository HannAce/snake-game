using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SnakeBordered");
    }

    public void OptionsButton()
    {
        Debug.Log("Options (oops, not yet implemented)");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
