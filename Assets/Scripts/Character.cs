using UnityEngine;

public class Character : MonoBehaviour
{
    public Health health;
    private StateBase currentState;

    public AttackState attackState;
    public IdleState idleState;
    public MoveState moveState;

    public Character attackTarget;

    public void Init() {
        currentState = idleState;
    }

    private void Update()
    {
        currentState?.StateUpdate();
    }

    public void ChangeState(StateBase target) {
        currentState = target;
    }
}
