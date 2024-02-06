using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : MonoBehaviour
{
    public GameObject target;  // Ÿ�� ������Ʈ�� Transform ������Ʈ�� �������ּ���.
    public float initialSpeed = 10f;
    public float maxHeight = 5f;

    private bool isAscending = true;
    private float currentHeight = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchProjectile();
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject;
                }
            }
        }
        if (isAscending)
        {
            currentHeight = transform.position.y;

            if (currentHeight >= maxHeight)
            {
                isAscending = false;
                rb.velocity = Vector3.zero;  // �ӵ��� 0���� ����� ����ϴ�.
                RotateTowardsTarget();
                LaunchProjectile();
            }
        }
    }
    void LaunchProjectile()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.velocity = direction * initialSpeed;
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
}
