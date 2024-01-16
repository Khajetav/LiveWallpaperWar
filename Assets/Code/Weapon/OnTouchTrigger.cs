using UnityEngine;
using static WeaponManager;

public class OnTouchTrigger : MonoBehaviour
{

    public GameObject objectToDrop;
    public DeathCounter death;
    public WeaponManager weaponManager;

    void Update()
    {
        // Check if the screen is touched
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponManager.selectedWeapon == WeaponType.Bomb)
            {
                DropTheBomb();
            }
            else if (weaponManager.selectedWeapon == WeaponType.Bullet)
            {

            }
        }
    }

    public void DropTheBomb()
    {
        // Get a bomb from the pool
        GameObject newObject = weaponManager.GetBomb();
        newObject.SetActive(true);

        // Get the screen position of the mouse
        Vector3 screenPosition = Input.mousePosition;

        // Convert the screen position to world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = -9; // Assuming a 2D game, set z to 0

        // Set the position of the bomb and initialize it
        newObject.transform.position = worldPosition;
        var bombBehavior = newObject.GetComponent<BombBehaviour>();
        bombBehavior.weaponPool = weaponManager;
        bombBehavior.DroppingTheBomb(worldPosition);
        bombBehavior.OnExplosion.AddListener(gameObject.GetComponent<ExplosionLight>().CreateAnExplosion);
        bombBehavior.death = death;
    }
}