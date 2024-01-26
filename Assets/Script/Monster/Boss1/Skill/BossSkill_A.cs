using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_A : MonsterSkill
{
    public GameObject firePosition;
    public GameObject bulletPrefab; // ź ������
    public int numberOfBullets = 8; // �� ���� ���ư��� ź�� ����
    public int loopMaxCount = 2;
    public int loopCurCount = 0;
    public float projectileSpeed = 3f; // ź �ӵ�
    public float projectileLifetime = 5f; // ź�� �����Ǿ� �ִ� �ð�
    public float gravity = -9.8f; // �߷� ���ӵ�
    

    public override void ApplyReaction(GameObject target)
    {
       
    }

    public override void ApplySkillEffect(GameObject target)
    {
        
    }

    public override void ExecuteAttack(GameObject _target)
    {
        target = _target;
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsSpout2");
    }

    public override void ActionAttack()
    {
        Vector3 spawnPosition = new Vector3(0, 7, 0); // x, y, z�� ��ǥ ���Դϴ�.

        for (int i = 0; i < numberOfBullets; i++)
        {
            // ������ �������� ź�� �߻�
            Vector3 randomDirection = Random.onUnitSphere.normalized;
            GameObject projectile = Instantiate(bulletPrefab, firePosition.transform.position, Quaternion.identity);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            //// �ʱ� �ӵ� ����
            projectileRb.velocity = randomDirection * projectileSpeed;

            //// �߷� ����
            projectileRb.useGravity = true;

            // ���� �ð��� ���� �Ŀ� ź�� ����
            Destroy(projectile, projectileLifetime);
        }

        if(++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;
        }
    }
}