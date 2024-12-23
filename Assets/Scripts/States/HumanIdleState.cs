using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdleState : IdleState
{
    public float lookRadius = 1f;
    private const string HUMANTAG = "Human";
    private const string ZOMBIETAG = "Zombie";
    private float idleWalkTimer = 0;
    private float idleWalkPeriodMax = 5;
    private float idleWalkPeriod = 5;

    public override void Init() { }

    public override void StateUpdate() {
        float zombieCount = 0;
        float humanCount = 0;
        float minDist = Mathf.Infinity;
        Character minDistZombie = null;
        foreach (Collider2D neirbor in Physics2D.OverlapCircleAll(_owner.transform.position, lookRadius)) {
            if (neirbor.CompareTag(HUMANTAG))
                humanCount++;
            else if (neirbor.CompareTag(ZOMBIETAG))
            {
                zombieCount++;
                float dist = Vector2.Distance(_owner.transform.position, neirbor.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    minDistZombie = neirbor.GetComponent<Character>();
                }
            }
        }
        if (minDistZombie) {
            if (Random.value < (zombieCount / (zombieCount + humanCount))) {
                _owner.attackTarget = minDistZombie;
                _owner.ChangeState(_owner.moveState);
            }
            else {
                MoveToRandomIndors();
            }
        }
        else
            IdleWalkUpdate();            
    }

    private void MoveToRandomIndors() {
        _owner.currentBuilding = _boot.level.GetRandomBuilding();
        _owner.moveState.targetPosition = _owner.currentBuilding.GetRandomPointInside();
        _owner.ChangeState(_owner.moveState);        
    }

    private void IdleWalkUpdate() {
        idleWalkTimer += Time.deltaTime;
        if (idleWalkTimer >= idleWalkPeriod) {
            idleWalkTimer = 0;
            idleWalkPeriod = Random.Range(0, idleWalkPeriodMax);
            _owner.moveState.targetPosition = _owner.currentBuilding.GetRandomPointInside();
            _owner.ChangeState(_owner.moveState);
        }
    }
}
