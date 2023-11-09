using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdleState : IdleState
{
    public float lookRadius = 5f;
    private const string HUMANTAG = "Human";
    private const string ZOMBIETAG = "Zombie";

    public override void Init() { }

    public override void StateUpdate() {
        float zombieCount = 0;
        float humanCount = 0;
        float minDist = Mathf.Infinity;
        Character minDistZombie = null;
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(owner.transform.position, lookRadius)) {
            if (collider.CompareTag(HUMANTAG))
                humanCount++;
            else if (collider.CompareTag(ZOMBIETAG))
            {
                zombieCount++;
                float dist = Vector2.Distance(owner.transform.position, collider.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    minDistZombie = collider.GetComponent<Character>();
                }
            }
        }
        if (minDistZombie) {
            if (Random.value > (zombieCount / (zombieCount + humanCount)))
            {
                owner.attackTarget = minDistZombie;
                owner.ChangeState(owner.attackState);
            }
            else {
                owner.moveState.targetPosition = Boot.gameField.GetRandomPoint();
                owner.ChangeState(owner.moveState);
            }
        }
    }

}
