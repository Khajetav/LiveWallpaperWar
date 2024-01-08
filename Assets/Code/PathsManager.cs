using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : MonoBehaviour
{
    // A list of paths
    [SerializeField]
    private List<Transform> pathPrefabs = new List<Transform>();
    // A converted list to avoid having to drag and drop each path's points manually.
    private List<PathInformation> pathInformation = new List<PathInformation>();
    // NPC prefab
    [SerializeField]
    private GameObject npcPrefab;

    private void Start()
    {
        // Converts to Path Information
        foreach (Transform pathPrefab in pathPrefabs)
        {
            PathInformation pInfo = new PathInformation();
            pInfo.startPoint = new Transform[] { pathPrefab.Find("StartPoint")?.transform };
            pInfo.middlePoint = new Transform[] { pathPrefab.Find("MiddlePoint")?.transform };
            pInfo.endPoint = new Transform[] { pathPrefab.Find("EndPoint")?.transform };
            pathInformation.Add(pInfo);
        }
        // Spawns every n seconds
        InvokeRepeating("SpawnNPC", 1,10);
    }

    private void SpawnNPC()
    {
        int random = Random.Range(0, pathInformation.Count);
        GameObject newGameObject = Instantiate(npcPrefab);
        newGameObject.GetComponent<NPCMovementController>().pI = pathInformation[random];
    }
}
