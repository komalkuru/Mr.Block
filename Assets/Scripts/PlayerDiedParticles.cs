using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedParticles : MonoBehaviour
{
    public ParticleSystem diedEffect;

    public void bulletShootEffect()
    {
        if (diedEffect != null)
        {
            ParticleSystem instance = Instantiate(diedEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
