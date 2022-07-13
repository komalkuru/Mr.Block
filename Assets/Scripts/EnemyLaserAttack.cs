using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserAttack : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float distance;

    [SerializeField] private LineRenderer lineOfSight;
    [SerializeField] private Gradient redColor;
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private PlayerDiedParticles playerDiedParticles;

    [SerializeField] private BoxCollider2D boxCollider2D;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        boxCollider2D = boxCollider2D.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
    }

    void Update()
    {
        
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right, distance);
        boxCollider2D.size = new Vector2(boxCollider2D.offset.x, boxCollider2D.size.y);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
                playerDiedParticles.Invoke("bulletShootEffect", 0f);
                gameOverController.Invoke("GameOver", 0.2f);
            }
        }
        lineOfSight.SetPosition(0, transform.position);
    }
}
