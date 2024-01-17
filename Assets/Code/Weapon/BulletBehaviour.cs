using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float scaleSpeed = 2.0f;
    public Vector3 targetPosition = new Vector3(0, 0, 0); // Adjust if needed

    void Start()
    {
        RotateTowardsTarget();
        //StartCoroutine(MoveScaleAndRotate());
    }

    private IEnumerator MoveScaleAndRotate()
    {
        while (transform.position.z < targetPosition.z)
        {
            // Move the bullet towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Scale down the bullet
            if (transform.localScale.magnitude > 0.02f)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);
            }

            yield return null;
        }

        gameObject.SetActive(false); // or Destroy(gameObject);
    }
    private void RotateTowardsTarget()
    {
        double angleRadians = Math.Atan2(targetPosition.y - transform.position.y,
                                         targetPosition.x - transform.position.x);

        // Convert to degrees
        float angleDegrees = (float)((1 - angleRadians) * (180 / Math.PI));
        Vector3 currentRotation = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, -(90-angleDegrees));
    }
}

