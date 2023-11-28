using UnityEngine;
using UnityEngine.AI;

public class MoveState : StateBase
{
    public float speed = 1f;
    public Vector3 targetPosition;
    public float attackDistance;

    public override void Init() {
    }

    public override void StartState(Character _owner) {
        base.StartState(_owner);
        RefreshDestination();
    }

    public override void StateUpdate() {
        if (owner.attackTarget)
        {
            RefreshDestination();
            if (Vector2.Distance(owner.transform.position, targetPosition) <= attackDistance)
                owner.ChangeState(owner.attackState);
        }
        else {
            if (Vector2.Distance(owner.transform.position, targetPosition) <= 0.01f) {
                owner.transform.position = targetPosition;
                owner.ChangeState(owner.idleState);
            }
        }
    }

    private void RefreshDestination() { 
        if (owner.attackTarget)
            targetPosition = owner.attackTarget.transform.position;
        if (owner.agent.isOnNavMesh)
            owner.agent.SetDestination(targetPosition);
        else
            Debug.LogWarning("Not on navMesh");        
    }
}
