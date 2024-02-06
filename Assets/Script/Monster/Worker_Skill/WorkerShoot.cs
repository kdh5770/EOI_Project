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
        animationEvent.ActionAttack += ActionAttack;

        target = _target;
        animator.SetTrigger("IsShootSkill");
        egg.GetComponent<ThorwObject>().SetDamage(damage);
        transform.LookAt(target.transform.position);
    }

    public override void ActionAttack()
    {
        Rigidbody EGG = egg.GetComponent<Rigidbody>();
        EGG.AddForce(transform.forward * encounter, ForceMode.Impulse);
        egg.transform.SetParent(null);

        animationEvent.ActionAttack -= ActionAttack;
    }

}
