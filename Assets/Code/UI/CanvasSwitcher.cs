using System.Collections;
using UnityEngine;
public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private CanvasGroup currentCanvasGroup;
    [SerializeField] private CanvasGroup goalCanvasGroup;
    public float animationDuration = 0.3f;
    public Vector3 firstGroupEndPosition = new Vector3(-500f, 0, 0);
    public Vector3 secondGroupStartPosition = new Vector3(500f, 0, 0);
    public void OnChangeCanvasButtonPress()
    {
        StartCoroutine(SwitchCanvasGroups(currentCanvasGroup, goalCanvasGroup));
    }


    private IEnumerator SwitchCanvasGroups(CanvasGroup currentGroup, CanvasGroup goalGroup)
    {
        currentGroup.interactable = false;
        currentGroup.blocksRaycasts = false;
        // scale down the current group
        yield return ScaleCanvasGroup(currentGroup, Vector3.one * 0.8f, animationDuration);
        // move and fade out the current group
        StartCoroutine(MoveCanvasGroup(currentGroup, firstGroupEndPosition, animationDuration));
        yield return FadeCanvasGroup(currentGroup, 0f, animationDuration);



        // prep the goal group
        goalGroup.transform.localScale = Vector3.one * 0.8f;
        goalGroup.alpha = 0f;
        goalGroup.transform.localPosition = secondGroupStartPosition;

        // fade in and move the goal group
        StartCoroutine(FadeCanvasGroup(goalGroup, 1f, animationDuration));
        yield return MoveCanvasGroup(goalGroup, Vector3.zero, animationDuration);
        // scale it up
        goalGroup.interactable = true;
        goalGroup.blocksRaycasts = true;
        StartCoroutine(ScaleCanvasGroup(goalGroup, Vector3.one, animationDuration));
    }
    private IEnumerator MoveCanvasGroup(CanvasGroup group, Vector3 newPosition, float duration)
    {
        Vector3 startPosition = group.transform.localPosition;
        float time = 0f;

        while (time < duration)
        {
            group.transform.localPosition = Vector3.Lerp(startPosition, newPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        group.transform.localPosition = newPosition;
    }

    private IEnumerator ScaleCanvasGroup(CanvasGroup group, Vector3 newScale, float duration)
    {
        Vector3 startScale = group.transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            group.transform.localScale = Vector3.Lerp(startScale, newScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        group.transform.localScale = newScale;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup group, float newAlpha, float duration)
    {
        float startAlpha = group.alpha;
        float time = 0f;

        while (time < duration)
        {
            group.alpha = Mathf.Lerp(startAlpha, newAlpha, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        group.alpha = newAlpha;
    }
}
