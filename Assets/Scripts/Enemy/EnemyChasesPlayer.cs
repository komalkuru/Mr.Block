using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;

/// <summary>
/// Enemy chases the Player.
/// </summary>

public class EnemyChasesPlayer : MonoBehaviour
{
    public float speed;
    public float stopPosition;
    private Transform target;
    [SerializeField] private GameOverController gameOverController;
    private float distance;

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
}
