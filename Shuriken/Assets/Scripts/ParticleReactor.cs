using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReactor : MonoBehaviour
{
    public ParticleSystem PrefabSpawnedOnCollision;
    public float SpawnChance = 0.33f;
    public Material ReactorMaterial;
    public Color EmissiveReactionColor;
    public Light ReactionLight;
    public float SpawnInset = 0.2f;

    private float glossiness = 0.0f;
    private Color emission = new Color(0.1f, 0.2f, 0.3f, 1f);

    public void OnCollision(int eventCount, Vector3 intersection, Vector3 normal)
    {
        glossiness = (float)eventCount / 20f;
        if (Random.Range(0.0f, 1.0f) < SpawnChance)
        {
            Instantiate(PrefabSpawnedOnCollision, intersection - normal * SpawnInset, Quaternion.LookRotation(normal));
            emission += EmissiveReactionColor;
        }
    }

    private void Update()
    {
        glossiness -= 0.01f;
        glossiness = Mathf.Clamp(glossiness, 0.42f, 0.98f);
        ReactorMaterial.SetFloat("_Glossiness", glossiness);
        emission *= 0.95f;
        ReactorMaterial.SetColor("_EmissionColor", emission);
        ReactionLight.color = emission;
    }
}