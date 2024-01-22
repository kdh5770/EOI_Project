using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerShout : MonsterSkill
{
    public Sprite effectImage;

    private void Start()
    {
        animationEvent.ActionAttack += ActionAttack;
    }
    public override void ApplyReaction(GameObject target) // 리액션 효과 (넉백)
    {
        Debug.Log("리액션 효과");
    }

    public override void ApplySkillEffect(GameObject target) // 스킬 효과
    {
        Gamemanager.instance.characterUI.TakeEffect(effectImage);
    }

    public override void ExecuteAttack(GameObject _target) // 공격 실행
    {
        target = _target;
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsShoutSkill");
        Debug.Log("샤우팅");
    }

    public override void ActionAttack()
    {
        ApplySkillEffect(target);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
