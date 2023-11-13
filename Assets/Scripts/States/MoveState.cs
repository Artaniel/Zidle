using UnityEngine;
using UnityEngine.AI;

public class MoveState : StateBase
{
    public float speed = 1f;
    public Vector3 targetPosition;
    public float attackDistance;

    public override void Init() {
    }

    public override void StartState() {
        if (owner.attackTarget)
            targetPosition = owner.attackTarget.transform.position;
        owner.agent.SetDestination(targetPosition);
        //owner.agent.isStopped = false;
    }

    public override void StateUpdate() {
        if (owner.attackTarget)
        {
            if (Vector2.Distance(owner.transform.position, targetPosition) <= attackDistance)
                //owner.agent.isStopped = true;
                owner.ChangeState(owner.attackState);
        }
        else {
            if (Vector2.Distance(owner.transform.position, targetPosition) <= 0.01f) {
                owner.transform.position = targetPosition;
                owner.ChangeState(owner.idleState);
                //owner.agent.isStopped = true;
            }
        }
    }
}
