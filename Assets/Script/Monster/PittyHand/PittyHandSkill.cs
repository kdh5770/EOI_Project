using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PittyHandSkill : Attack, ISkillEffect
{

    public Transform qte;
    public GameObject target;
    public GameObject pittyHand;

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
        pittyHand.GetComponent<NavMeshAgent>().enabled = false;
        pittyHand.transform.position = qte.position + qte.transform.forward * 0.03f;
        Vector3 lookDirection = new Vector3(qte.transform.position.x - pittyHand.transform.position.x, 0, qte.transform.position.z - pittyHand.transform.position.z);
        Quaternion desiredRotation = Quaternion.LookRotation(lookDirection, Vector3.up) * Quaternion.Euler(-60, 0, 0);
        pittyHand.transform.rotation = desiredRotation;
        StartCoroutine(TestQTE());
    }

    IEnumerator TestQTE()
    {
        bool isloop = true;
        while (isloop)
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 1f);

            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Player"))
                    {
                        collider.GetComponent<CharacterHealth>().TakeDamage(1);

                        if (collider.GetComponent<CharacterHealth>().GetDie())
                        {
                            isloop = false;
                        }
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
        Debug.Log("����");
    }
}
