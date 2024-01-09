using System.Collections;
using UnityEngine;

public class LightSway : MonoBehaviour
{
    private Light light;
    public float upperSpotAngleRange = 30f; // Upper bound of the spot angle.
    public float lowerSpotAngleRange = 15f; // Lower bound of the spot angle.
    public float swaySpeed = 1f;

    private float time;

    void Start()
    {
        // Start the sway effect
        light = GetComponent<Light>();
        StartCoroutine(Sway());
    }

    private IEnumerator Sway()
    {
        while (true)
        {
            light.spotAngle = ((upperSpotAngleRange - lowerSpotAngleRange) / 2f) * (Mathf.Sin(time * swaySpeed) + 1) + lowerSpotAngleRange;


            // Calculate the rotation for each axis
            //float rotationX = Mathf.Sin(time * swaySpeedX) * swayAmountX;
            //float rotationY = Mathf.Sin(time * swaySpeedY) * swayAmountY;
            //float rotationZ = Mathf.Sin(time * swaySpeedZ) * swayAmountZ;

            // Apply the rotation to the light
            //transform.localEulerAngles = new Vector3(0,0,rotationZ);

            // Increment the time
            time += Time.deltaTime;
            yield return null;
        }
    }
}
