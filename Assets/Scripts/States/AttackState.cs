using UnityEngine;

public class AttackState : StateBase
{
    public float damage = 1f;
    public float speed = 1f;
    private float timer = 0;
    public float maxDist = 1f;

    public GameObject VFXPrefab;

    public override void Init() { }

    public override void StateUpdate() {
        if (_owner.attackTarget.health.isDead || !_owner.attackTarget) {
            SwichToIdle();
            return;
        }
        
        if (Vector2.Distance(_owner.transform.position, _owner.attackTarget.transform.position) <= maxDist) {
            timer += Time.deltaTime;
            float delay = 1f / speed;
            while (timer > delay && !_owner.attackTarget.health.isDead) {
                timer -= delay;
                Attack();
            }
        } else {
            SwichToIdle();            
        }
    }

    private void SwichToIdle() {
        _owner.attackTarget = null;
        _owner.ChangeState(_owner.idleState);
    }

    private void Attack() {
        _owner.attackTarget.health.Damage(damage);
        if (VFXPrefab) {
            GameObject vfx = Pool.GetPool(VFXPrefab, _owner.attackTarget.transform.position,
                Quaternion.LookRotation(Vector3.ProjectOnPlane(_owner.attackTarget.transform.position - _owner.transform.position, Vector3.forward)));
        }
        _boot.economy.OnAttack(_owner);
    }
}
