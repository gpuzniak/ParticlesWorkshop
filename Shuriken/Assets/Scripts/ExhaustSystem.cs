using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustSystem : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleReactor reactingObject = other.GetComponent<ParticleReactor>();
        if (reactingObject != null) { 
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            if (numCollisionEvents > 0)
            {
                reactingObject.OnCollision(numCollisionEvents, collisionEvents[0].intersection, collisionEvents[0].normal);
            }
        }
    }
}
