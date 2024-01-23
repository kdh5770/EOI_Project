using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : MonoBehaviour
{
    public Transform target;  // 타겟 오브젝트의 Transform 컴포넌트를 연결해주세요.
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
        if (isAscending)
        {
            currentHeight = transform.position.y;

            if (currentHeight >= maxHeight)
            {
                isAscending = false;
                rb.velocity = Vector3.zero;  // 속도를 0으로 만들어 멈춥니다.
                RotateTowardsTarget();
                LaunchProjectile();
            }
        }
    }
    void LaunchProjectile()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * initialSpeed;
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
}
