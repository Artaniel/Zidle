using UnityEngine;
using UnityEngine.AI;

public class MoveState : StateBase
{
    public Vector3 targetPosition;
    public float attackDistance;

    public override void Init() {
    }

    public override void StartState(Character owner, Boot boot) {
        base.StartState(owner, boot);
        RefreshDestination();
    }

    public override void StateUpdate() {
        if (_owner.attackTarget)
        {
            RefreshDestination();
            if (Vector2.Distance(_owner.transform.position, targetPosition) <= attackDistance)
                _owner.ChangeState(_owner.attackState);
        }
        else {
            if (Vector2.Distance(_owner.transform.position, targetPosition) <= 0.1f) {
                _owner.transform.position = targetPosition;
                _owner.ChangeState(_owner.idleState);
            }
        }
    }

    private void RefreshDestination() { 
        if (_owner.attackTarget)
            targetPosition = _owner.attackTarget.transform.position;
        if (_owner.agent.isOnNavMesh)
            _owner.agent.SetDestination(targetPosition);
        else
            Debug.LogWarning("Not on navMesh");        
    }
}
