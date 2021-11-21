using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostParticlesController : MonoBehaviour
{
    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        GameManager.Instance.startBoost += PlayParticles;
    }

    void PlayParticles()
    {
        particles.Play();
    }
}
