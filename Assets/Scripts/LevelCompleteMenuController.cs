using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Level;

public class LevelCompleteMenuController : MonoBehaviour
{
    public Button nextButton;
    public Button backButton;
    public Button exitButton;

    private void Start()
    {
        nextButton.onClick.AddListener(NextLevel);
        backButton.onClick.AddListener(BackToLobby);
        exitButton.onClick.AddListener(QuitLevel);
    }
    public void LevelComplete()
    {
        gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        Debug.Log("Reloading Next Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToLobby()
    {
        Debug.Log("Reloading the lobby Scene...");
        SceneManager.LoadScene(0);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
}
