using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// The enemy shoots at the player. When the bullet touches the player, it will be destroyed and particles will
/// form.
/// </summary>

public class Bullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public ParticleSystem shootEffect;

void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.gameObject.GetComponent<Bullet>() != null) // when bullet touches the player it will detroy and call the particles.
        {            
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
        bulletShootEffect();
    }

    void bulletShootEffect()
    {
        if (shootEffect != null)
        {
            ParticleSystem instance = Instantiate(shootEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
