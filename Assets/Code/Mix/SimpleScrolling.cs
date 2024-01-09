using UnityEngine;
using UnityEngine.UI;

public class SimpleScrolling : MonoBehaviour
{
    public float scrollXSpeed = 0.1f;
    public float scrollYSpeed = 0.1f;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * scrollXSpeed, Time.realtimeSinceStartup * scrollYSpeed);
    }

}
