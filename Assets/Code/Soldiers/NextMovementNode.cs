using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMovementNode : MonoBehaviour
{
    private GetAllMovementNodes movementNodeManager;

    public void Awake()
    {
        // Automatically fetch the GetAllMovementNodes component from the same GameObject
        movementNodeManager = GetComponent<GetAllMovementNodes>();
        if (movementNodeManager == null)
        {
            Debug.LogError("GetAllMovementNodes component not found on the GameObject.");
        }
    }
    // COLLISION EVENT
    private void OnCollisionEnter(Collision collision)
    {
         HandleNodeCollision(collision.gameObject);
    }

    // event logic
    private void HandleNodeCollision(GameObject collidedObject)
    {
        // Remove the collided node from the list
        movementNodeManager.movementNodes.Remove(gameObject);

        // Check if there are any nodes left
        if (movementNodeManager.movementNodes.Count == 0)
        {
            // No more nodes, destroy the object this script is attached to
            Destroy(collidedObject);
        }
        else
        {
            // Move to the next node in the list, if required
            // Example: collidedObject.transform.position = movementNodeManager.movementNodes[0].transform.position;
        }

        // Safety check to ensure movementNodeManager is assigned
        if (movementNodeManager == null)
        {
            Debug.LogError("MovementNodeManager is not assigned!");
            return;
        }
    }
}
