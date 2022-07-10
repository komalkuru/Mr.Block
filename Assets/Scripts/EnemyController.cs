using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float ySpeed;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    // Start is called before the first frame update
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
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (localScale.y < 0 || localScale.y > 0)
            localScale.y *= -1;

        transform.localScale = localScale;
    }
}
