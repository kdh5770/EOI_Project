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
    public override void ApplyReaction(GameObject target) // ���׼� ȿ�� (�˹�)
    {
        Debug.Log("���׼� ȿ��");
    }

    public override void ApplySkillEffect(GameObject target) // ��ų ȿ��
    {
        Gamemanager.instance.characterUI.TakeEffect(effectImage);
    }

    public override void ExecuteAttack(GameObject _target) // ���� ����
    {
        target = _target;
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsShoutSkill");
        Debug.Log("������");
    }

    public override void ActionAttack()
    {
        ApplySkillEffect(target);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
