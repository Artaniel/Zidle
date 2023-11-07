using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIdleState : IdleState
{
    public NavMeshAgent agent;
    private HumanFactory _humanFactory;

    public override void Init(HumanFactory humanFactory) {
        _humanFactory = humanFactory;
    }

    public override void StateUpdate()
    {
        if (_humanFactory.humanList == null || _humanFactory.humanList.Count < 1)
            return;
        NavMeshPath path = new NavMeshPath();
        float minPathLength = Mathf.Infinity;
        Character closestHuman = null;
        foreach (Character human in _humanFactory.humanList) {
            agent.CalculatePath(human.transform.position, path);
            float pathLength = GetPathLength(owner.transform.position, path);
            if (pathLength < minPathLength) {
                minPathLength = pathLength;
                closestHuman = human;
            }
        }
        if (closestHuman) {
            owner.attackTarget = closestHuman;
            owner.ChangeState(owner.attackState);
        }
    }

    private float GetPathLength(Vector3 startPoint, NavMeshPath path) {
        float result = 0;
        Vector3 previousCorner = startPoint;
        foreach (Vector3 corner in path.corners)
        {
            result += Vector3.Distance(previousCorner, corner);
            previousCorner = corner;
        }
        return result;
    }
}
