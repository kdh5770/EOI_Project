using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_B : MonsterSkill
{
    // (원거리 장판 공격)
    [SerializeField]
    private GameObject skill_b;
    [SerializeField]
    private Transform shootposition;

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
    }
    public override void ActionAttack()
    {
        Instantiate(skill_b, shootposition.position, Quaternion.identity);

        animationEvent.ActionAttack -= ActionAttack;
    }
}
