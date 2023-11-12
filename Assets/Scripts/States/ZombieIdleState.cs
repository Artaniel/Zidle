using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIdleState : IdleState
{
    public override void StateUpdate()
    {
        if (Boot.humanFactory.humanList == null || Boot.humanFactory.humanList.Count < 1) { 
            Debug.LogWarning("can't get humanFactory list");
            return;
        }
        if (!owner.agent.isOnNavMesh) {
            Debug.LogWarning("agent not on navmesh");
            return;
        }
        Character closestHuman = GetClosest();
        if (closestHuman) {
            owner.attackTarget = closestHuman;
            owner.ChangeState(owner.moveState);
        }
    }

    private Character GetClosest() {
        float minPathLength = Mathf.Infinity;
        Character closestHuman = null;
        foreach (Character human in Boot.humanFactory.humanList)
        {
            if (Vector3.Distance(owner.transform.position, human.transform.position) < minPathLength)
            {
                minPathLength = Vector3.Distance(owner.transform.position, human.transform.position);
                closestHuman = human;
            }
        }
        return closestHuman;
    }

    private Character GetcClosestFromNavmesh() {
        NavMeshPath path = new NavMeshPath();
        float minPathLength = Mathf.Infinity;
        Character closestHuman = null;
        foreach (Character human in Boot.humanFactory.humanList)
        {
            owner.agent.CalculatePath(human.transform.position, path);
            float pathLength = GetPathLength(owner.transform.position, path);
            if (pathLength < minPathLength)
            {
                minPathLength = pathLength;
                closestHuman = human;
            }
        }
        return closestHuman;
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
