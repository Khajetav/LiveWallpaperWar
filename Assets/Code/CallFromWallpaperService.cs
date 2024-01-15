using System.Collections;
using UnityEngine;

// Place this script within the "CallFromWallpaperService" GameObject.
// Alternatively, in the Wallpaper Service within the onVisibilityChanged method,
// Make sure to adjust the first parameter of UnitySendMessage to match the GameObject name of this script.
public class CallFromWallpaperService : MonoBehaviour
{
    public CanvasGroup mainCanvasGroup;
    public OnTouchTrigger bombTouchEvent;

    private Coroutine coroutineOnFadeOut;
    private Coroutine coroutineOnFadeIn;

    public bool enableBomb = false;

    private void Update()
    {
#if UNITY_EDITOR
        bombTouchEvent.enabled = enableBomb;
#endif
    }

    // Invoked by the Wallpaper Service upon visibility changes.
    // Receives a boolean value indicating the user's current screen.
    public void OnVisibilityChange(string boolean)
    {

        // If the condition is true, it means the user is in a desktop; if false, the user is in an application.
        if (boolean == "true")
        {
            if (coroutineOnFadeIn != null)
                StopCoroutine(coroutineOnFadeIn);
            coroutineOnFadeOut = StartCoroutine(DoFadeOut());
            bombTouchEvent.enabled = true;
        }
        else
        {
            if (coroutineOnFadeOut != null)
                StopCoroutine(coroutineOnFadeOut);
            mainCanvasGroup.gameObject.SetActive(true);
            mainCanvasGroup.alpha = 0;
            coroutineOnFadeIn = StartCoroutine(DoFadeIn());
            bombTouchEvent.enabled = false;
        }
    }

    private IEnumerator DoFadeIn()
    {
        float duration = 0.6f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            mainCanvasGroup.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }
        mainCanvasGroup.alpha = 1f;
    }

    private IEnumerator DoFadeOut()
    {
        float duration = 0.6f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            mainCanvasGroup.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }
        mainCanvasGroup.alpha = 0f;
        mainCanvasGroup.gameObject.SetActive(false);
    }
}
