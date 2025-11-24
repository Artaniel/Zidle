using UnityEngine;
using UnityEngine.AI;

public class Character : ManualMonobehaviour
{
    public Health health;
    [SerializeField] private StateBase currentState;

    public AttackState attackState;
    public IdleState idleState;
    public MoveState moveState;

    public Character attackTarget;
    public NavMeshAgent agent;

    [HideInInspector] public Building currentBuilding;

    public Infection infection;

    public override void Init() {
        currentState = idleState;
        currentState.StartState(this, _boot);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public override void ManualFixedUpdate() {
        Debug.Log("Character FixedUpdate");
        if (!health.isDead)
            currentState?.StateUpdate();
    }

    public void ChangeState(StateBase newStane) {
        Debug.Log($"Changing state from {currentState.GetType().Name} to {newStane.GetType().Name}");
        currentState = newStane;
        newStane.StartState(this, _boot);
    }
}
