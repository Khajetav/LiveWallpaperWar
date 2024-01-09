using UnityEngine;
using UnityEngine.UI;

public class SimpleScrolling : MonoBehaviour
{
    [SerializeField] private RawImage scrollingObjectImage;
    public float scrollingSpeed;

    void Update()
    {
        scrollingObjectImage.uvRect = new Rect(scrollingObjectImage.uvRect.position + new Vector2(scrollingSpeed, scrollingSpeed/5) * Time.deltaTime, scrollingObjectImage.uvRect.size);
    }
}
