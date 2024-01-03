using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerShout : Attack, ISkillEffect
{

    public Transform qte;
    public GameObject target;
    public GameObject Worker;

    public void ApplyReaction(GameObject target) // ���׼� ȿ�� (�˹�)
    {
        Debug.Log("���׼� ȿ��");
    }

    public void ApplySkillEffect(GameObject target) // ��ų ȿ��
    {
        Debug.Log("��ų ȿ��");
    }

    public override void ExecuteAttack() // ���� ����
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 11f); // ���� ���� �����ϱ�

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    animator.SetTrigger("IsShoutSkill");
                    Debug.Log("������");
                    break;
                }
            }
        }
    }
}
