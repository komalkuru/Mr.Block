using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy Patrooling between the walls
/// </summary>
/// 

public class EnemyController : MonoBehaviour
{
    private float ySpeed;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        ySpeed = -1f;
        moveSpeed = 3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            ySpeed *= -1f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, ySpeed * moveSpeed);
    }

    void LateUpdate()
    {
        CheckWall();
    }

    void CheckWall()
    {
        if (localScale.y < 0 || localScale.y > 0)
            localScale.y *= -1;

        transform.localScale = localScale;
    }
}
