using UnityEngine;

public class PauseManager : MonoBehaviour
{
    #if !UNITY_EDITOR
    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            var allBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            foreach (var behaviour in allBehaviours)
            {
                behaviour.enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            var allBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            foreach (var behaviour in allBehaviours)
            {
                behaviour.enabled = true;
            }
        }
    }
    #endif
}
