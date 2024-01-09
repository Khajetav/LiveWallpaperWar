using UnityEngine;

public class OnTouchTrigger : MonoBehaviour
{
    public GameObject objectToDrop;

    void Update()
    {
        // Check if the screen is touched
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate the object
            GameObject newObject = Instantiate(objectToDrop);

            // Get the screen position of the mouse
            Vector3 screenPosition = Input.mousePosition;

            // Convert the screen position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            Debug.Log(worldPosition);
            // Pass the position to the DroppingTheBomb method
            newObject.GetComponent<BombBehaviour>().DroppingTheBomb(worldPosition);
        }
    }
}