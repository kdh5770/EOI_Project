using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_D : MonsterSkill
{
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
        animator.SetTrigger("IsSkillD");
        Debug.Log("샤우팅, 몬스터 소환");
    }
    public override void ActionAttack()
    {
        ApplySkillEffect(target);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
