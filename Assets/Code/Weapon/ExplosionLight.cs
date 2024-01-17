using System.Collections;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
    public float bombExplosionHeight = -0.05f;
    public float bombExplosionRange = 10f;
    public float bombExplosionIntensity = 100f;
    public float bombExplosionStartDuration = 0.2f;
    public float bombExplosionEndDuration = 2f;
    public LightShadows lightShadows;

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
        lightComp.shadows = lightShadows;
        lightComp.shadowBias = 0f;  
        lightComp.shadowNormalBias = 0.4f;  
        lightComp.shadowNearPlane = 0.2f;

        bombExplosionIntensity = PlayerPrefs.GetInt("LightIntensitySettings", 100);
        bombExplosionRange = PlayerPrefs.GetInt("LightRangeSettings", 10);
        if(PlayerPrefs.GetInt("ShadowSettings", 1) == 1)
            lightShadows = LightShadows.Hard;
        else
            lightShadows = LightShadows.Soft;

        string colorHex = PlayerPrefs.GetString("bombColour", "#FFE1B9");
        Color lightColor;
        if (ColorUtility.TryParseHtmlString(colorHex, out lightColor))
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
        float duration = bombExplosionStartDuration;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            // Debug.Log(light.range);
            light.range = Mathf.Lerp(0, bombExplosionRange, currentTime / duration);
            light.intensity = Mathf.Lerp(0, bombExplosionIntensity, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = bombExplosionRange;
        StartCoroutine(AnimateExplosionEnd(light));
    }
    private IEnumerator AnimateExplosionEnd(Light light)
    {
        // Decrease range and intensity over 2 seconds
        float duration = bombExplosionEndDuration;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            light.range = Mathf.Lerp(bombExplosionRange, 0, currentTime / duration);
            light.intensity = Mathf.Lerp(bombExplosionIntensity, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        light.range = 0f;
        light.intensity = 0f;

        Destroy(light.gameObject);
    }
}
