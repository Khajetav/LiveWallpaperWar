using System.Collections;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("DroppingToTheGround");
    }

    public void DroppingTheBomb(Vector2 touchCoordinates)
    {

        transform.position = new Vector3(touchCoordinates.x, touchCoordinates.y, Camera.main.transform.position.z);

        // Start the coroutine to move the object towards the touch coordinates
        StartCoroutine("DroppingToTheGround");
    }

    private IEnumerator DroppingToTheGround()
    {
        float speed = 5.0f;
        float scaleSpeed = 1.0f;  // Speed at which the object scales down

        // Continue the loop until the z position is approximately 0 and scale is close to 0
        while (Mathf.Abs(transform.position.z) > 0.001f || transform.localScale.magnitude > 0.001f)
        {
            // Calculate the new position.
            Vector3 newPosition = transform.position;
            newPosition.z = Mathf.MoveTowards(newPosition.z, 0, speed * Time.deltaTime);
            transform.position = newPosition;

            // Reduce the scale towards 0
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);

            // Yield until the next frame.
            yield return null;
        }

        Destroy(gameObject);
    }

}
