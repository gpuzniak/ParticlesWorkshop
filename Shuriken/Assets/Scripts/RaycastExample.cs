using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public ParticleSystem FiringParticleSystem;
    public ParticleSystem CollidingParticleSystem;
    public LayerMask RayCastLayerMask;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan);

        if (Physics.Raycast(ray, out hit, RayCastLayerMask))
        {
            CollidingParticleSystem.transform.position = hit.point;
            CollidingParticleSystem.transform.rotation = Quaternion.LookRotation(hit.normal);

            Debug.DrawRay(hit.point, hit.normal, Color.yellow);
        }
    }
}