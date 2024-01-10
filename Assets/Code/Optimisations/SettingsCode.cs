using UnityEngine;
using TMPro;
using System;

public class SettingsCode : MonoBehaviour
{
    public TextMeshProUGUI wallpaperFPSText;
    public TextMeshProUGUI graphicsText;
    private int[] fpsOptions = { 30, 60 };
    private string[] graphicsOptions = { "LOW","MED","HIGH","ULTRA"};
    private int currentWallpaperFPS;
    private string currentGraphics;

    void Start()
    {
        currentWallpaperFPS = PlayerPrefs.GetInt("wallpaperFPS", 30);
        currentGraphics = PlayerPrefs.GetString("currentGraphics", "HIGH");
        Application.targetFrameRate = currentWallpaperFPS;
        UpdateUIText();
    }

    public void ChangeWallpaperFPS(bool increase)
    {
        int index = Array.IndexOf(fpsOptions, currentWallpaperFPS);
        index += increase ? 1 : -1;
        if (index >= fpsOptions.Length) index = 0;
        if (index < 0) index = fpsOptions.Length - 1;
        // Update the current FPS
        currentWallpaperFPS = fpsOptions[index];

        PlayerPrefs.SetInt("wallpaperFPS", currentWallpaperFPS);
        PlayerPrefs.Save();
        UpdateUIText();
    }
    public void ChangeGraphics(bool increase)
    {
        int index = Array.IndexOf(graphicsOptions, currentGraphics);
        index += increase ? 1 : -1;
        if (index >= graphicsOptions.Length) index = 0;
        if (index < 0) index = graphicsOptions.Length - 1;
        // Update the current FPS
        currentGraphics = graphicsOptions[index];
        switch (index)
        {
            case 0:
                QualitySettings.SetQualityLevel(0); // Very Low
                break;
            case 1:
                QualitySettings.SetQualityLevel(2); // Medium
                break;
            case 2:
                QualitySettings.SetQualityLevel(3); // High
                break;
            case 3:
                QualitySettings.SetQualityLevel(5); // Ultra
                break;
            default:
                QualitySettings.SetQualityLevel(0);
                break;
        }
        PlayerPrefs.SetString("currentGraphics", currentGraphics);
        PlayerPrefs.Save();
        UpdateUIText();
    }
    private void UpdateUIText()
    {
        wallpaperFPSText.text = currentWallpaperFPS.ToString();
        graphicsText.text = currentGraphics.ToString();
    }

}
