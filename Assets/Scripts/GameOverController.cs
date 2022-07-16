using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// When the player touches the enemy or the enemy touches the player, it will active the gameover Canvas.
/// </summary>

public class GameOverController : MonoBehaviour
{
    public Button retryButton;
    public Button backButton;
    public Button exitButton;

    private void Awake()
    {
        retryButton.onClick.AddListener(ReloadLevel);
        backButton.onClick.AddListener(BackToLobby);
        exitButton.onClick.AddListener(QuitGame);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading current Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToLobby()
    {
        Debug.Log("Reloading the lobby Scene...");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
