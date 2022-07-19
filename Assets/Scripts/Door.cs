using UnityEngine;
using Assets.Scripts.Level;

public class Door : MonoBehaviour
{
    [SerializeField] private LevelCompleteMenuController levelCompleteMenuController;
    public bool gameWin = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameWin)
        {        
            Debug.Log("Level finished by the player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            levelCompleteMenuController.LevelComplete();
            gameWin = false;
        }
    }
}
