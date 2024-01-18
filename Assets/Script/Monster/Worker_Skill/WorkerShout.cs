using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerShout : MonsterSkill
{

    public override void ApplyReaction(GameObject target) // 리액션 효과 (넉백)
    {
        Debug.Log("리액션 효과");
    }

    public override void ApplySkillEffect(GameObject target) // 스킬 효과
    {
        Debug.Log("스킬 효과");
    }

    public override void ExecuteAttack(GameObject _target) // 공격 실행
    {
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsShoutSkill");
        Debug.Log("샤우팅");
    }
}
