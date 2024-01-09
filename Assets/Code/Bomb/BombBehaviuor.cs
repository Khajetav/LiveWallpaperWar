using System.Collections;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private bool hasCollided = false;

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
        float speed = 2.0f;
        // Continue the loop until the z position is approximately 0 and scale is close to 0
        while (Mathf.Abs(transform.position.z) > 0.001f)
        {
            // Calculate the new position.
            Vector3 newPosition = transform.position;
            newPosition.z = Mathf.MoveTowards(newPosition.z, 0, speed * Time.deltaTime);
            transform.position = newPosition;
            // Yield until the next frame.
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            //Destroy(other.gameObject);
        }
    }
}