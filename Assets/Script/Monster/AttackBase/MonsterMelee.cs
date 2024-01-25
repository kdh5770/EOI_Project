using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{


    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;
        transform.LookAt(target.transform.position);
        animator.SetTrigger("IsMelee");
    }

    public override void ActionAttack()
    {
        target.GetComponent<CharacterHealth>().TakeDamage(damage);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
