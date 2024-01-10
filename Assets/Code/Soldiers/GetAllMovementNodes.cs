using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllMovementNodes : MonoBehaviour
{
    // nodeParent dictates which object the nodes belong to
    // soldierNodeParent would show the movement nodes for soldiers
    // tankNodeParent would show the movement nodes for tanks and etc
    [SerializeField] GameObject nodeParent;
    public List<GameObject> movementNodes { get; private set; }
    public void LoadAllNodes()
    {
        movementNodes = new List<GameObject>();
        if (nodeParent != null)
        {
            foreach (Transform child in nodeParent.transform)
            {
                // Debug.Log("Node added " + child.name);
                movementNodes.Add(child.gameObject);
            }
        }
    }
}
