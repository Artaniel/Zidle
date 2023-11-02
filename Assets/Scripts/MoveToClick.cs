using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MoveToClick : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Awake()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            agent.SetDestination(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
        }
    }

}
