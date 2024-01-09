using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTargetReached;
    public void OnTriggerEnter(Collider other)
    {
        OnTargetReached.Invoke();
    }
}

