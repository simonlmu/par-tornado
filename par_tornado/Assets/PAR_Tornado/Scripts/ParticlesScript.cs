using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour
{
    public ParticleSystem celebrationParticleSystem;

    public void PlayCelebrationEffect()
    {
        celebrationParticleSystem.Play();
    }
}
