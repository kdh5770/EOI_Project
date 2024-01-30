using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_A : MonsterSkill
{
    // 땅 칠 때 플레이어 밑에서 촉수 튀어나와서 공격
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
        animator.SetTrigger("IsSkillA");
        Debug.Log("땅 치는 순간 플레이어 위치에 땅에서 촉수 나와서 공격");
    }
    public override void ActionAttack()
    {

        animationEvent.ActionAttack -= ActionAttack;
    }
}
