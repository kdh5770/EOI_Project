using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherThrow : Attack
{
    [Header("�߻�ü ������")]
    public GameObject BulletEftPre;
    [Header("�߻� ��ġ")]
    public Transform BulletTf;
    [Header("������ �߻�ü")]
    public GameObject BulletEft;
    private Vector3 direction;

    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;

        // Ÿ�� ���� ���
        Vector3 targetPosition = target.transform.position;
        targetPosition.y += 1f; // ���̸� 1��ŭ �ø��ϴ�.

        Vector3 targetDirection = (targetPosition - BulletTf.position).normalized;

        // �߻�ü ���� ��� (Ÿ�� ��ġ - �߻� ��ġ)
        direction = targetDirection;
        transform.LookAt(targetPosition);

        animator.SetTrigger("isThrow");
    }

    public override void ActionAttack()
    {
        // �߻�ü ���� �� ���� ����
        BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.LookRotation(direction));

        // �߻�ü�� ���� ���Ͽ� �̵�
        BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f; // Ÿ�� �������� �߻�ü�� �̵���ŵ�ϴ�.
        Destroy(BulletEft, 5f);
        animationEvent.ActionAttack -= ActionAttack;
    }
}