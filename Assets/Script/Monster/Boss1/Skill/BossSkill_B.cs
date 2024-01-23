using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_B : MonsterSkill
{
    public GameObject spoutEffect;
    public Transform firePosition;
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
        target = _target;
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsSpout");
    }
    public override void ActionAttack()
    {
        GameObject preObj = Instantiate(spoutEffect, firePosition.position, Quaternion.identity);

        // �÷��̾� �������� ȸ����Ű��
        Vector3 playerDirection = (target.transform.position - firePosition.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

        // ȸ�� ������ ����
        float rotationAngle = 20f;

        // y������ ȸ����Ű�� (�÷��̾� ������ �������� ȸ��)
        Vector3 eulerRotation = new Vector3(rotationAngle, toRotation.eulerAngles.y, 0f);
        preObj.transform.eulerAngles = eulerRotation;

        animationEvent.ActionAttack -= ActionAttack;
    }

}
