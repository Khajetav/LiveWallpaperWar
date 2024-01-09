using System.Collections;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
    public float bombExplosionHeight = -0.05f;

    public void CreateAnExplosion(Vector3 explosionPosition)
    {
        Debug.Log("Invoked");
        // Create a new GameObject
        GameObject lightGameObject = new GameObject("LightExplosion");
        explosionPosition.z = bombExplosionHeight;
        lightGameObject.transform.position = explosionPosition;

        // Add the Light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set the light to be a point light
        lightComp.type = LightType.Point;
        lightComp.renderMode = LightRenderMode.ForcePixel;
        lightComp.range = 0f;
        lightComp.intensity = 0f;
        lightComp.shadows = LightShadows.Soft;
        lightComp.shadowBias = 0f;  
        lightComp.shadowNormalBias = 0.4f;  
        lightComp.shadowNearPlane = 0.2f;
        // Set light color to FFE1B9
        Color lightColor;
        if (ColorUtility.TryParseHtmlString("#FFE1B9", out lightColor))
        {
            lightComp.color = lightColor;
        }
        else
        {
            Debug.LogError("Invalid color code");
        }

        // Start the coroutine to handle light animation
        StartCoroutine(AnimateExplosionStart(lightComp));
    }

    private IEnumerator AnimateExplosionStart(Light light)
    {
        // Increase range from 0 to 10 in 0.3 seconds
        float duration = 0.2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            Debug.Log(light.range);
            light.range = Mathf.Lerp(0, 10, currentTime / duration);
            light.intensity = Mathf.Lerp(0, 100, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 10f;
        StartCoroutine(AnimateExplosionEnd(light));
    }
    private IEnumerator AnimateExplosionEnd(Light light)
    {
        // Decrease range and intensity over 2 seconds
        float duration = 2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            light.range = Mathf.Lerp(10, 0, currentTime / duration);
            light.intensity = Mathf.Lerp(100, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 0f;
        light.intensity = 0f;

        // Turn off light and destroy its GameObject
        Destroy(light.gameObject);
    }

    /*
    private IEnumerator AnimateLight(Light light)
    {


        // Decrease range and intensity over 2 seconds
        duration = 2f;
        timer = 0;
        while (timer <= duration)
        {
            light.range = Mathf.Lerp(10, 0, timer / duration);
            light.intensity = Mathf.Lerp(100, 0, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Turn off light and destroy its GameObject
        light.gameObject.SetActive(false);
        Destroy(light.gameObject);
    }
    */
}
