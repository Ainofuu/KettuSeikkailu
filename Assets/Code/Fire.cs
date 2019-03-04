using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    bool flickering = false;

    public float maxIncrease;
    public float maxDecrease;
    public float strength;
    public float rateDamping;
    
    public List<Light> lights = new List<Light>();
    public ParticleSystem ps;

    float baseIntensity = 2;

    private void Start()
    {
        if (lights != null)
        {
            // Assuming all the lights have the same intensity.
            baseIntensity = lights[0].intensity;
            foreach (Light light in lights)
            {
                light.intensity = 0;
            }
        }

        if (ps != null)
        {
            ps.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Didn't find a particle system for" + gameObject.name);
        }
    }

    public void LightFire()
    {
        StartCoroutine(Flicker());
        ps.gameObject.SetActive(true);
    }

    public void TurnOffFire()
    {
        flickering = false;
        foreach (Light light in lights)
        {
            light.intensity = 0;
        }
        ps.gameObject.SetActive(false);
    }

    IEnumerator Flicker()
    {
        flickering = true;

        foreach (Light light in lights)
        {
            light.intensity = baseIntensity;
        }

        while (flickering)
        {
            foreach (Light light in lights)
            {
                light.intensity = Mathf.Lerp(light.intensity, 
                    Random.Range(baseIntensity - maxDecrease, 
                                 baseIntensity + maxIncrease), 
                    strength * Time.deltaTime);
            }
            yield return new WaitForSeconds(rateDamping);
        }
        foreach (Light light in lights)
        {
            light.intensity = 0;
        }
    }
}
