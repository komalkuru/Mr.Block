using UnityEngine;

public class PlayerDiedParticles : MonoBehaviour
{
    public ParticleSystem diedEffect;
    [SerializeField] private Transform player;
    private bool flag = true;

    private void Start()
    {
        if(flag)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void bulletShootEffect()
    {
        if (diedEffect != null && flag)
        {
            gameObject.SetActive(true);
            ParticleSystem instance = Instantiate(diedEffect, player.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
            flag = false;
        }
    }
}
