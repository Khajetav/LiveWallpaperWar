using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextMovementNode : MonoBehaviour
{
    public UnityEvent OnCollision;
    private GetAllMovementNodes movementNodeManager;
    // NodeSoldier for soldier movement nodes
    // NodeTank for tank nodes and etc
    [SerializeField] private string nodeTag = "NodeSoldier"; 


    public void Awake()
    {
        // Automatically fetch the GetAllMovementNodes component from the same GameObject
        movementNodeManager = GetComponent<GetAllMovementNodes>();
        if (movementNodeManager == null)
        {
            Debug.LogError("GetAllMovementNodes component not found on the GameObject.");
        }
    }


    //// COLLISION EVENT
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Trigger detected!");
    //    if (other.CompareTag(nodeTag))
    //    {
    //        OnCollision.Invoke();
    //    }
    //}
}
