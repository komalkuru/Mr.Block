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
    private bool playerDetect = true;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {        
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right, distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player") && playerDetect)
            {
                Destroy(hitInfo.collider.gameObject);
                playerDiedParticles.Invoke("bulletShootEffect", 0f);
                playerDetect = false;
                //gameOverController.Invoke("GameOver", 0.2f);                
            }
        }
        lineOfSight.SetPosition(0, transform.position);
    }
}
