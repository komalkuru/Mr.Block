using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject LevelSelection;

    private void Start()
    {
        startButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(EndGme);
    }

    public void PlayGame()
    {
        Debug.Log("button clicked");
        LevelSelection.SetActive(true);
    }

    public void EndGme()
    {
        Application.Quit();
    }
}
