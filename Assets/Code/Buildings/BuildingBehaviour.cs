using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bomb")
        {
            Debug.Log(gameObject.name + " is on FIRE!!!!!!!!!!!!!!!!!!!");
        }
    }
}
