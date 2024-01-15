using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerShoot : Attack, ISkillEffect
{
    public void ApplyReaction(GameObject target) // ���׼� ȿ�� (�˹�)
    {
        Debug.Log("���׼� ȿ��");
    }

    public void ApplySkillEffect(GameObject target) // ��ų ȿ��
    {
        Debug.Log("��ų ȿ��");
    }

    public override void ExecuteAttack(GameObject _target) // ���� ����
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 11f); // ���� ���� �����ϱ�

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    animator.SetTrigger("IsShootSkill");
                    Debug.Log("�� Ǫ��");
                    break;
                }
            }
        }
    }
}
