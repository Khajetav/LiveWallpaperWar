using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BombBehaviour : MonoBehaviour
{
    public UnityEvent<Vector3> OnExplosion;
    public DeathCounter death;

    public void DroppingTheBomb(Vector2 touchCoordinates)
    {

        transform.position = new Vector3(touchCoordinates.x, touchCoordinates.y, Camera.main.transform.position.z);

        // Start the coroutine to move the object towards the touch coordinates
        StartCoroutine("DroppingToTheGround");
    }

    private IEnumerator DroppingToTheGround()
    {
        // Debug.Log("BOOOOOOOOMB!!!!!");
        float speed = 5.0f;
        Vector3 newPosition = transform.position;
        // Continue the loop until the z position is approximately 0 and scale is close to 0
        while (Mathf.Abs(transform.position.z) > 0.001f)
        {
            // Calculate the new position.

            newPosition.z = Mathf.MoveTowards(newPosition.z, 0, speed * Time.deltaTime);
            transform.position = newPosition;
            // Yield until the next frame.
            yield return null;
        };
        OnExplosion.Invoke(newPosition);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            // Debug.Log(other.gameObject.name);
            death.OnKill(1);
            Destroy(other.gameObject);
        }
    }
}