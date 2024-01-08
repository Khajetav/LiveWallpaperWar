using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCMovementController : MonoBehaviour
{
    public float movementSpeed = 2f;
    public PathInformation pI;
    private Transform target;
    private int currentTargetIndex;

    private void Start()
    {
        target = pI.startPoint[Random.Range(0, pI.startPoint.Length)];
        transform.position = target.position;
        currentTargetIndex = 0;
    }

    private void Update()
    {
        // Check if the NPC is close enough to the current target
        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            UpdateTarget();
        }

        MoveTowardsTarget();
    }

    private void UpdateTarget()
    {
        // Update the target based on the currentTargetIndex
        currentTargetIndex++;

        switch (currentTargetIndex)
        {
            case 1:
                target = pI.middlePoint[Random.Range(0,pI.middlePoint.Length)];
                break;
            case 2:
                target = pI.endPoint[Random.Range(0, pI.endPoint.Length)];
                break;
            case 3:
                Destroy(gameObject);
                break;
        }
    }

    private void MoveTowardsTarget()
    {
        // Move the NPC towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }
}
