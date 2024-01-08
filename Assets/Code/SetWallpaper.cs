using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWallpaper : MonoBehaviour
{
    public void SetLiveWallpaper()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("SetWallpaper");
        }
    }
}
