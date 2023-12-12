using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdleState : IdleState
{
    public float lookRadius = 1f;
    private const string HUMANTAG = "Human";
    private const string ZOMBIETAG = "Zombie";

    public override void Init() { }

    public override void StateUpdate() {
        float zombieCount = 0;
        float humanCount = 0;
        float minDist = Mathf.Infinity;
        Character minDistZombie = null;
        foreach (Collider2D neirbor in Physics2D.OverlapCircleAll(owner.transform.position, lookRadius)) {
            if (neirbor.CompareTag(HUMANTAG))
                humanCount++;
            else if (neirbor.CompareTag(ZOMBIETAG))
            {
                zombieCount++;
                float dist = Vector2.Distance(owner.transform.position, neirbor.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    minDistZombie = neirbor.GetComponent<Character>();
                }
            }
        }
        if (minDistZombie) {
            if (Random.value < (zombieCount / (zombieCount + humanCount)))
            {
                owner.attackTarget = minDistZombie;
                owner.ChangeState(owner.moveState);
            }
            else {
                owner.moveState.targetPosition = Boot.level.GetRandomPoint();
                owner.ChangeState(owner.moveState);
            }
        }
    }

}
