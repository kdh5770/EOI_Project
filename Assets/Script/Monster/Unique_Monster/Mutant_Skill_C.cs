using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_C : MonsterSkill
{
    // ��� ���� ����(���Ÿ�)
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
        animator.SetTrigger("IsSkillC");
        Debug.Log("������� ���ð����� ����");
    }
    public override void ActionAttack()
    {
        ApplySkillEffect(target);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
