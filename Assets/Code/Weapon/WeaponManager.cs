using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType
    {
        Bomb,
        Bullet
    }

    public GameObject bombPrefab;
    public GameObject bulletPrefab;
    public WeaponType selectedWeapon;
    private Queue<GameObject> bombs = new Queue<GameObject>();
    private Queue<GameObject> bullets = new Queue<GameObject>();
    public Transform poolWeaponObjectParent;

    public GameObject GetBomb()
    {
        if (bombs.Count == 0)
            AddBombs(10);
        return bombs.Dequeue();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count == 0)
            AddBullets(10);
        return bullets.Dequeue();
    }

    private void AddBombs(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, poolWeaponObjectParent);
            bomb.SetActive(false);
            bombs.Enqueue(bomb);
        }
    }

    private void AddBullets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, poolWeaponObjectParent);
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }
    }

    public void ReturnWeaponObjectToPool(GameObject obj, WeaponType type)
    {
        obj.transform.position = new Vector3(0,0,0);
        obj.SetActive(false);
        switch (type)
        {
            case WeaponType.Bomb:
                bombs.Enqueue(obj);
                break;
            case WeaponType.Bullet:
                bullets.Enqueue(obj);
                break;
        }
    }
}
