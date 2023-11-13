using UnityEngine;

public class AttackState : StateBase
{
    public float damage = 1f;
    public float speed = 1f;
    private float timer = 0;
    public float maxDist = 1f;

    public override void Init() { }

    public override void StartState() { }

    public override void StateUpdate()
    {
        if (Vector2.Distance(owner.transform.position, owner.attackTarget.transform.position) <= maxDist)
        {
            timer += Time.deltaTime;
            float delay = 1f / speed;
            while (timer > delay && !owner.attackTarget.health.isDead) {
                timer -= delay;
                Attack();
            }
            if (owner.attackTarget.health.isDead)
                owner.ChangeState(owner.idleState);
        }
    }

    private void Attack() {
        owner.attackTarget.health.Damage(damage);
    }
}
