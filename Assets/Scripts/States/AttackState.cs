using UnityEngine;

public class AttackState : StateBase
{
    public float damage = 1f;
    public float speed = 1f;
    private float timer = 0;
    public float maxDist = 1f;

    public Character target;

    public override void Init() { }

    public override void StateUpdate()
    {
        if (Vector2.Distance(owner.transform.position, target.transform.position) <= maxDist)
        {
            timer += Time.deltaTime;
            float delay = 1f / speed;
            while (timer > delay && !target.health.isDead) {
                timer -= delay;
                Attack();
            }
            if (target.health.isDead)
                owner.ChangeState(owner.idleState);
        }
    }

    private void Attack() {
        target.health.Damage(damage);
    }
}
