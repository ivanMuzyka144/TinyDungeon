using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MiracleParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    
    public void PlayParticle()
    {
        EmissionModule em = particleSystem.emission;
        em.rate = 100;
        StartCoroutine(StopMiracleCoroutine());
    }

    IEnumerator StopMiracleCoroutine()
    {
        yield return new WaitForSeconds(1);
        EmissionModule em = particleSystem.emission;
        em.rate = 0;
    }
}
