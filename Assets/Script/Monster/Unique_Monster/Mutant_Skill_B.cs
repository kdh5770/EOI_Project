using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_B : MonsterSkill
{
    // (원거리 장판 공격)
    public override void ApplyReaction(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplySkillEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsSkillB");
        Debug.Log("장판 공격");
    }
    public override void ActionAttack()
    {

        animationEvent.ActionAttack -= ActionAttack;
    }
}
