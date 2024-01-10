using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSManager : MonoBehaviour
{
    public int targetFps = 30;
    private void Start()
    {
        Application.targetFrameRate = PlayerPrefs.GetInt("wallpaperFPS", 30);
    }
}
