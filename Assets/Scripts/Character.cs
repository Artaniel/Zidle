using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private Boot _boot;
    public Health health;
    [SerializeField] private StateBase currentState;

    public AttackState attackState;
    public IdleState idleState;
    public MoveState moveState;

    public Character attackTarget;
    public NavMeshAgent agent;

    [HideInInspector] public Building currentBuilding;

    public void Init(Boot boot) {
        _boot = boot;
        currentState = idleState;
        currentState.StartState(this, boot);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        if (!health.isDead)
            currentState?.StateUpdate();
    }

    public void ChangeState(StateBase newStane) {
        currentState = newStane;
        newStane.StartState(this, _boot);
    }
}
