using UnityEngine;
using UnityEngine.AI;

public class MoveState : StateBase
{
    public float speed = 1f;
    private NavMeshAgent agent;
    public Vector3 targetPosition;
    public float attackDistance;

    public override void Init() {
        agent = owner.agent;
    }

    public override void StateUpdate() {
        if (owner.attackTarget)
            targetPosition = owner.attackTarget.transform.position;
        agent.SetDestination(targetPosition);

        float deltaDistance = speed * Time.deltaTime;
        if (deltaDistance < Vector2.Distance(owner.transform.position, agent.path.corners[0]))
            owner.transform.position += (agent.path.corners[0] - owner.transform.position).normalized * deltaDistance;
        else
            owner.transform.position = agent.path.corners[0];

        if (owner.attackTarget)
        {
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
}
