using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Health health;
    private StateBase currentState;

    public AttackState attackState;
    public IdleState idleState;
    public MoveState moveState;

    public Character attackTarget;
    public NavMeshAgent agent;

    public void Init() {
        currentState = idleState;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        currentState?.StateUpdate();
    }

    public void ChangeState(StateBase target) {
        currentState = target;
    }
}
