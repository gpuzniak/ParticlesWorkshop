using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTimer : MonoBehaviour
{
    public float Lifetime = 1.0f;

    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void Update()
    {
        if(Time.time > spawnTime + Lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
