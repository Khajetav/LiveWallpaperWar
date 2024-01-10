using System.Collections;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
    public float bombExplosionHeight = -0.05f;

    public void CreateAnExplosion(Vector3 explosionPosition)
    {
        GameObject lightGameObject = new GameObject("LightExplosion");
        explosionPosition.z = bombExplosionHeight;
        lightGameObject.transform.position = explosionPosition;
        Light lightComp = lightGameObject.AddComponent<Light>();


        lightComp.type = LightType.Point;
        lightComp.renderMode = LightRenderMode.Auto;
        lightComp.range = 0f;
        lightComp.intensity = 0f;
        lightComp.shadows = LightShadows.Hard;
        lightComp.shadowBias = 0f;  
        lightComp.shadowNormalBias = 0.4f;  
        lightComp.shadowNearPlane = 0.2f;

        Color lightColor;
        if (ColorUtility.TryParseHtmlString("#FFE1B9", out lightColor))
        {
            lightComp.color = lightColor;
        }
        else
        {
            Debug.LogError("Invalid color code");
        }
        StartCoroutine(AnimateExplosionStart(lightComp));
    }

    private IEnumerator AnimateExplosionStart(Light light)
    {
        // Increase range from 0 to 10 in 0.3 seconds
        float duration = 0.2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            // Debug.Log(light.range);
            light.range = Mathf.Lerp(0, 5, currentTime / duration);
            light.intensity = Mathf.Lerp(0, 40, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 5f;
        StartCoroutine(AnimateExplosionEnd(light));
    }
    private IEnumerator AnimateExplosionEnd(Light light)
    {
        // Decrease range and intensity over 2 seconds
        float duration = 2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            light.range = Mathf.Lerp(5, 0, currentTime / duration);
            light.intensity = Mathf.Lerp(40, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 0f;
        light.intensity = 0f;

        Destroy(light.gameObject);
    }
}
