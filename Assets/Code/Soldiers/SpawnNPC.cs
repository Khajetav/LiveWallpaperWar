using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    int pathIndex = 0;
    public Transform npcSpawnPoint;
    public GameObject soldierPrefab;
    public List<GameObject> parentNodeList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("ReleaseNPC", 0, 15);
    }

    void ReleaseNPC()
    {

        GameObject newSoldierObject = Instantiate(soldierPrefab);
        newSoldierObject.GetComponent<GetAllMovementNodes>().AssignNodeParent(parentNodeList[pathIndex]);
        newSoldierObject.GetComponent<GetAllMovementNodes>().LoadAllNodes();
        GameObject firstMovementNode = newSoldierObject.GetComponent<GetAllMovementNodes>().movementNodes[0];
        // Set the position
        Vector3 newPosition = new Vector3(firstMovementNode.transform.position.x, firstMovementNode.transform.position.y, -0.01f);
        newSoldierObject.transform.position = newPosition;

        pathIndex++;
        if (parentNodeList.Count <= pathIndex)
            pathIndex = 0;
    }
}
