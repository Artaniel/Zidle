using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Health health;
    [SerializeField] private StateBase currentState;

    public AttackState attackState;
    public IdleState idleState;
    public MoveState moveState;

    public Character attackTarget;
    public NavMeshAgent agent;

    public void Init() {
        currentState = idleState;
        currentState.StartState(this);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        if (!health.isDead)
            currentState?.StateUpdate();
    }

    public void ChangeState(StateBase newStane) {
        currentState = newStane;
        newStane.StartState(this);
    }
}
