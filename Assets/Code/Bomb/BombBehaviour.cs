using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BombBehaviour : MonoBehaviour
{
    private bool hasCollided = false;
    public UnityEvent<Vector3> OnExplosion;
    void Start()
    {
        // Find the BombManager object in the scene
        GameObject bombManager = GameObject.Find("BombManager");
        if (bombManager != null)
        {
            // Get the ExplosionLight component from the BombManager
            ExplosionLight explosionLight = bombManager.GetComponent<ExplosionLight>();
            if (explosionLight != null)
            {
                // If not null, add the CreateAnExplosion method to the UnityEvent
                OnExplosion.AddListener(explosionLight.CreateAnExplosion);
            }
            else
            {
                Debug.LogError("ExplosionLight component not found on BombManager.");
            }
        }
        else
        {
            Debug.LogError("BombManager object not found.");
        }
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
        Debug.Log("Invoking OnExplosion event");
        OnExplosion.Invoke(newPosition);
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