using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy chases the Player.
/// </summary>

public class EnemyChasesPlayer : MonoBehaviour
{
    public float speed;
    public float stopPosition;
    private Transform target;
    [SerializeField] private GameOverController gameOverController;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameOverController.GameOver();
            //GetComponent<GameOverController>().enabled = true;
        }
    }
}
