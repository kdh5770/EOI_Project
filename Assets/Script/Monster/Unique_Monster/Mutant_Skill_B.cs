using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_B : MonsterSkill
{
    // (���Ÿ� ���� ����)
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
        Debug.Log("���� ����");
    }
    public override void ActionAttack()
    {

        animationEvent.ActionAttack -= ActionAttack;
    }
}
