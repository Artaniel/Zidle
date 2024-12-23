using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIdleState : IdleState
{
    public override void StartState(Character owner, Boot boot) {
        base.StartState(owner, boot);

        if (_boot.humanFactory.humanList == null || _boot.humanFactory.humanList.Count < 1) {
            Debug.LogWarning("can't get humanFactory list");
            return;
        }
        if (!_owner.agent.isOnNavMesh) {
            Debug.LogWarning("agent not on navmesh");
            return;
        }

        TryAttackClosest();
    }

    public override void StateUpdate() {
        TryAttackClosest();
    }

    protected void TryAttackClosest() {
        Character closestHuman = GetClosestAlive();
        if (closestHuman) {
            _owner.attackTarget = closestHuman;
            _owner.ChangeState(_owner.moveState);
        }
    }

    protected Character GetClosestAlive() {
        float minPathLength = Mathf.Infinity;
        Character closestHuman = null;
        foreach (Character human in _boot.humanFactory.humanList) {
            if (!human.health.isDead && Vector3.Distance(_owner.transform.position, human.transform.position) < minPathLength) {
                minPathLength = Vector3.Distance(_owner.transform.position, human.transform.position);
                closestHuman = human;
            }
        }
        return closestHuman;
    }

    protected Character GetcClosestFromNavmesh() {
        NavMeshPath path = new NavMeshPath();
        float minPathLength = Mathf.Infinity;
        Character closestHuman = null;
        foreach (Character human in _boot.humanFactory.humanList) {
            _owner.agent.CalculatePath(human.transform.position, path);
            float pathLength = GetPathLength(_owner.transform.position, path);
            if (pathLength < minPathLength) {
                minPathLength = pathLength;
                closestHuman = human;
            }
        }
        return closestHuman;
    }

    protected float GetPathLength(Vector3 startPoint, NavMeshPath path) {
        float result = 0;
        Vector3 previousCorner = startPoint;
        foreach (Vector3 corner in path.corners) {
            result += Vector3.Distance(previousCorner, corner);
            previousCorner = corner;
        }
        return result;
    }
}
