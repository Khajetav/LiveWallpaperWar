using UnityEngine;

public class OnTouchTrigger : MonoBehaviour
{
    public GameObject objectToDrop;
    public DeathCounter death;
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

            // Pass the position to the DroppingTheBomb method
            newObject.GetComponent<BombBehaviour>().DroppingTheBomb(worldPosition);
            newObject.GetComponent<BombBehaviour>().OnExplosion.AddListener(gameObject.GetComponent<ExplosionLight>().CreateAnExplosion);
            newObject.GetComponent<BombBehaviour>().death = death;
        }
    }

    public void DropTheBomb()
    {
        GameObject newObject = Instantiate(objectToDrop);
        newObject.GetComponent<BombBehaviour>().DroppingTheBomb(new Vector3(0,3,-9));
        newObject.GetComponent<BombBehaviour>().OnExplosion.AddListener(gameObject.GetComponent<ExplosionLight>().CreateAnExplosion);
        newObject.GetComponent<BombBehaviour>().death = death;
    }
}