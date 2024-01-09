using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScaling : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("ScaleDownCoroutine");
    }

    private IEnumerator ScaleDownCoroutine()
    {

        float scaleSpeed = 2f; // Speed of scaling down per second

        while (transform.localScale.magnitude > 0.1f) // Check if scale is close to zero
        {
            // Decrease the scale uniformly
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }

}
