using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerShoot : MonsterSkill
{
    public GameObject egg;
    public int encounter = 10;

    public override void ApplyReaction(GameObject target) // ���׼� ȿ�� (�˹� ������)
    {
        Debug.Log("���׼� ȿ��");
    }

    public override void ApplySkillEffect(GameObject target) // ��ų ȿ��
    {
        Debug.Log("��ų ȿ��");
    }

    public override void ExecuteAttack(GameObject _target) // ���� ����
    {
        egg.GetComponent<ThorwObject>().SetDamage(10);
        transform.LookAt(_target.transform.position);
        StartCoroutine(AnimatorDelay());

    }

    IEnumerator AnimatorDelay()
    {
        animator.SetTrigger("IsShootSkill");

        yield return new WaitForSeconds(.3f);
        Rigidbody EGG = egg.GetComponent<Rigidbody>();
        EGG.AddForce(transform.forward * encounter, ForceMode.Impulse);
        egg.transform.SetParent(null);
    }
}
