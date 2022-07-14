using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When the player touches the enemy or the enemy touches the player, it will active the gameover Canvas.
/// </summary>

public class GameOverController : MonoBehaviour
{
    public void GameOver()
    {
        gameObject.SetActive(true);
    }
}
