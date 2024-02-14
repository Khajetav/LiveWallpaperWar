using UnityEngine;
using static WeaponManager;

public class OnTouchTrigger : MonoBehaviour
{
    public DeathCounter death;
    public WeaponManager weaponManager;

    public bool canInteract = false;

    private bool isTouching = false;
    private Vector2 touchStartPosition;
    private float tapThreshold = 0.5f;

    void Update()
    {
        // Check for a touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record start position and mark as touching
                    touchStartPosition = touch.position;
                    isTouching = true;
                    break;

                case TouchPhase.Ended:
                    if (isTouching && Vector2.Distance(touchStartPosition, touch.position) < tapThreshold)
                    {
                        // It's a tap, perform your action
                        if (canInteract && weaponManager.selectedWeapon == WeaponType.Bomb)
                        {
                            DropTheBomb();
                        }
                        else if (canInteract && weaponManager.selectedWeapon == WeaponType.Bullet)
                        {
                            // Perform action for bullet
                        }
                    }
                    // Reset the touching flag
                    isTouching = false;
                    break;
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