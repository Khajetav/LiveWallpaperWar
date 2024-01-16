using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static WeaponManager;

public class BombBehaviour : MonoBehaviour
{
    public UnityEvent<Vector3> OnExplosion;
    public DeathCounter death;
    public WeaponManager weaponPool;
    private GameObject bombImage;

    public void DroppingTheBomb(Vector2 touchCoordinates)
    {
        bombImage = transform.GetChild(0).gameObject;
        transform.position = new Vector3(touchCoordinates.x, touchCoordinates.y, Camera.main.transform.position.z);

        // Start the coroutine to move the object towards the touch coordinates
        StartCoroutine("DroppingToTheGround");
        StartCoroutine("ScaleDownBombImage");
    }

    private IEnumerator DroppingToTheGround()
    {
        // Debug.Log("BOOOOOOOOMB!!!!!");
        float speed = 15.0f;
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

        weaponPool.ReturnWeaponObjectToPool(gameObject, WeaponType.Bomb);
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

    private IEnumerator ScaleDownBombImage()
    {
        float scaleSpeed = 2.0f; // Speed of scaling down per second
        bombImage.transform.localScale = new Vector3(1, 1, 1);
        while (bombImage.transform.localScale.magnitude > 0.02f) // Check if scale is close to zero
        {
            // Decrease the scale uniformly
            bombImage.transform.localScale = Vector3.MoveTowards(bombImage.transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }
}