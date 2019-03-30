using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustSystem : MonoBehaviour
{
    public ParticleSystem Spray;
    public List<ParticleCollisionEvent> collisionEvents;
    public bool SpawnCrystals = true;
    public ParticleSystem CrystalParticleSystem;
    public float CrystalSize = 0.5f;

    private List<ParticleSystem.Particle> CrystalParticles;

    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        CrystalParticles = new List<ParticleSystem.Particle>();
    }

    private void Update()
    {
        CrystalParticleSystem.SetParticles(CrystalParticles.ToArray(), CrystalParticles.Count);
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = Spray.GetCollisionEvents(other, collisionEvents);
        if (numCollisionEvents > 0)
        {
            ParticleReactor reactiveObject = other.GetComponent<ParticleReactor>();

            if (reactiveObject != null) {

                reactiveObject.OnCollision(numCollisionEvents, collisionEvents[0].intersection, collisionEvents[0].normal);
            }
            else if(SpawnCrystals == true) {
                ParticleSystem.Particle newCrystalParticle = new ParticleSystem.Particle();
                newCrystalParticle.position = collisionEvents[0].intersection;
                newCrystalParticle.startSize = CrystalSize * Random.Range(0.5f, 1.5f);
                newCrystalParticle.rotation3D = Quaternion.LookRotation(Random.onUnitSphere).eulerAngles;
                //newCrystalParticle.startLifetime = 10f;
                CrystalParticles.Add(newCrystalParticle);
            }
        }
    }
}
