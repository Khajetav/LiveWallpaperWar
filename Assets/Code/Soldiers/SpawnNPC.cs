using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    int rotation = 0;
    public Transform npcSpawnPoint;
    public GameObject soldierPrefab;
    public List<GameObject> parentNodeList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("ReleaseNPC", 0, 60);
    }

    void ReleaseNPC()
    {
        Instantiate(soldierPrefab, npcSpawnPoint);


        if (parentNodeList.Count  rotation)
            rotation = 0;
    }
}
