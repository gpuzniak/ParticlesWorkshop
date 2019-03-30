using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGridExample : MonoBehaviour
{
    public ParticleSystem TargetSystem;
    public Vector2Int Dimensions;
    public float ParticleSize;

    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particles = new ParticleSystem.Particle[Dimensions.x * Dimensions.y];
        for (int x = 0, i = 0; x < Dimensions.x; x++)
        {
            for (int y = 0; y < Dimensions.y; y++, i++)
            {
                particles[i].startSize = ParticleSize * Random.Range(0.5f, 1.5f);
                particles[i].position = new Vector3(x, y, 0);
                particles[i].startColor = new Color((float)x / Dimensions.x, (float)y / Dimensions.y, 0.5f, 1.0f);
            }
        }
    }


    void Update()
    {
        for(int i = 0; i < particles.Length; i++)
        {
            particles[i].startSize = ParticleSize;// * Random.Range(0.5f, 1.5f);
            particles[i].position = new Vector3(particles[i].position.x, 
                                                particles[i].position.y, 
                                                Mathf.Sin(Time.time + (particles[i].position.x + particles[i].position.y) / 10f));
        }

        TargetSystem.SetParticles(particles, particles.Length);
    }
}
