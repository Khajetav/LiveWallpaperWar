using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSManager : MonoBehaviour
{
    public int targetFps = 24;
    private void Start()
    {
        Application.targetFrameRate = 24;
    }
}
