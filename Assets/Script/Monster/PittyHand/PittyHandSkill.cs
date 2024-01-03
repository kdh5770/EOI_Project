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
        pittyHand.transform.position = qte.position + qte.transform.forward * 0.3f;
        pittyHand.transform.LookAt(qte.transform.position);
        pittyHand.transform.rotation = Quaternion.Euler(- 90, qte.transform.rotation.y, 0);
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
