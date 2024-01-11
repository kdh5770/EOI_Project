using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public GameObject bulletPrefab; // ź ������
    public int numberOfBullets = 8; // �� ���� ���ư��� ź�� ����
    public float projectileSpeed = 5f; // ź �ӵ�
    public float projectileLifetime = 5f; // ź�� �����Ǿ� �ִ� �ð�
    public float gravity = -9.8f; // �߷� ���ӵ�

    private void skill()
    {
        Vector3 spawnPosition = new Vector3(0, 7, 0); // x, y, z�� ��ǥ ���Դϴ�.

        for (int i = 0; i < numberOfBullets; i++)
        {
            // ������ �������� ź�� �߻�
            Vector3 randomDirection = Random.onUnitSphere.normalized;
            GameObject projectile = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            // �ʱ� �ӵ� ����
            projectileRb.velocity = randomDirection * projectileSpeed;

            // �߷� ����
            projectileRb.useGravity = true;

            // ���� �ð��� ���� �Ŀ� ź�� ����
            Destroy(projectile, projectileLifetime);
        }
    }
}