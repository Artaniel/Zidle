using UnityEngine;

public class AttackState : StateBase
{
    public float damage = 1f;
    public float speed = 1f;
    private float timer = 0;
    public float maxDist = 1f;

    public GameObject VFXPrefab;

    public override void Init() { }

    public override void StateUpdate()
    {
        if (owner.attackTarget.health.isDead || !owner.attackTarget) {
            SwichToIdle();
            return;
        }
        if (Vector2.Distance(owner.transform.position, owner.attackTarget.transform.position) <= maxDist)
        {
            timer += Time.deltaTime;
            float delay = 1f / speed;
            while (timer > delay && !owner.attackTarget.health.isDead) {
                timer -= delay;
                Attack();
            }
        }
        else {
            SwichToIdle();            
        }
    }

    private void SwichToIdle() {
        owner.attackTarget = null;
        owner.ChangeState(owner.idleState);
    }

    private void Attack() {
        owner.attackTarget.health.Damage(damage);
        if (VFXPrefab) {
            GameObject vfx = Pool.GetPool(VFXPrefab, owner.attackTarget.transform.position,
                Quaternion.LookRotation(Vector3.ProjectOnPlane(owner.attackTarget.transform.position - owner.transform.position, Vector3.forward)));
        }
        Boot.economy.OnAttack(owner);
    }
}
