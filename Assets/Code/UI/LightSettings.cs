using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LightSettings : MonoBehaviour
{
    public Slider intensitySlider, rangeSlider, shadowSlider;
    public TextMeshProUGUI intensitySliderText, rangeSLiderText, shadowSliderText;

    private void Start()
    {
        intensitySlider.value = PlayerPrefs.GetInt("LightIntensitySettings", 100);
        rangeSlider.value = PlayerPrefs.GetInt("LightRangeSettings", 10);
        shadowSlider.value = PlayerPrefs.GetInt("ShadowSettings", 1);
    }

    public void LightIntensitySliderChange()
    {
        intensitySliderText.text = intensitySlider.value.ToString();
        PlayerPrefs.SetInt("LightIntensitySettings",(int) intensitySlider.value);
    }

    public void LightRangeSliderChange()
    {
        rangeSLiderText.text = rangeSlider.value.ToString();
        PlayerPrefs.SetInt("LightRangeSettings", (int)rangeSlider.value);
    }

    public void ShadowSliderChange()
    {
        if (shadowSlider.value == 0)
            shadowSliderText.text = "Min";
        else
            shadowSliderText.text = "Max";
        PlayerPrefs.SetInt("ShadowSettings", (int)shadowSlider.value);
    }

}
