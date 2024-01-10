using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
    public ParticleSystem fireParticle;
    public Light fireLight;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bomb")
        {
            // Debug.Log(gameObject.name + " is on FIRE!!!!!!!!!!!!!!!!!!!");
            fireParticle.Play();
            fireLight.gameObject.SetActive(true);
            fireLight.range = 1f;
            fireLight.intensity = 5f;
            StartCoroutine(InvokeAfterDelay(10));
        }
    }

    IEnumerator InvokeAfterDelay(float s)
    {
        // Wait for 'n' seconds
        yield return new WaitForSeconds(s);

        // Code to execute after the delay
        StartCoroutine(AnimateExplosionEnd(fireLight));
    }

    private IEnumerator AnimateExplosionEnd(Light light)
    {
        // Decrease range and intensity over 2 seconds
        float duration = 5f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            light.range = Mathf.Lerp(1, 0, currentTime / duration);
            light.intensity = Mathf.Lerp(5, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 0f;
        light.intensity = 0f;
        fireLight.gameObject.SetActive(false);
    }
}
