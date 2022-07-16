using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy floow the player & it will detroy when it touch to the wall and respawn at random position.
/// </summary>

public class EnemyAIChasing : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeShots;

    public GameObject bullet;
    private Transform player;

    public static EnemyAIChasing instance;
    public Transform[] respawnPoint;
    [SerializeField] private GameObject enemyPrefab;
    int randomSpot;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        randomSpot = Random.Range(0, respawnPoint.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeShots;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }   
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.GetComponent<Wall>() != null)
        {
            Destroy(gameObject);
            Respawn();
        }
    }

    public void Respawn()
    {        
        Instantiate(enemyPrefab, respawnPoint[randomSpot].position, Quaternion.identity);
    }
}
