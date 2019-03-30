using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmokeOrWhatever : MonoBehaviour
{
    public ParticleSystem TargetParticleSystem;
    public Slider EmissionSlider;

    void Update()
    {
        ParticleSystem.EmissionModule emission = TargetParticleSystem.emission;
        emission.rateOverTime = EmissionSlider.value;
    }
}
