using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GetAllMovementNodes movementNodeManager;
    private GameObject currentNode;
    private Coroutine movementCoroutine;
    public float movementSpeed = 5f; 
    public float rotationSpeed = 20f;
    private int nodeIndex = 0;
    private void Awake()
    {
        
    }

    public void LoadNextNode()
    {
        nodeIndex++;
        if (nodeIndex != movementNodeManager.movementNodes.Count)
        {
            currentNode = movementNodeManager.movementNodes[nodeIndex];
            if (movementCoroutine != null)
                StopCoroutine(movementCoroutine);
            movementCoroutine = StartCoroutine(MoveTowardsNode());
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        movementNodeManager = GetComponent<GetAllMovementNodes>();
        movementNodeManager.LoadAllNodes();
        // Grab the first node from the movementNodeManager's movementNodes list
        if (movementNodeManager.movementNodes.Count > 0)
        {
            currentNode = movementNodeManager.movementNodes[0];
            movementCoroutine = StartCoroutine(MoveTowardsNode());
        }
    }

    // moves and rotates towards the next node
    private IEnumerator MoveTowardsNode()
    {
        Transform cachedTransform = transform; 
        Vector3 startPosition = cachedTransform.position;
        Vector3 targetPosition = currentNode.transform.position;

        Vector3 targetDirection = targetPosition - startPosition;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90;

        while (Vector3.Distance(cachedTransform.position, targetPosition) > 0.1f)
        {
            // Move towards the current node
            cachedTransform.position = Vector3.MoveTowards(cachedTransform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Slerp rotation only affects the z-axis
            float currentZAngle = cachedTransform.eulerAngles.z;
            float newZAngle = Mathf.LerpAngle(currentZAngle, targetAngle, rotationSpeed * Time.deltaTime);
            cachedTransform.rotation = Quaternion.Euler(0, 0, newZAngle);

            yield return null;
        }

        LoadNextNode();
    }


}
