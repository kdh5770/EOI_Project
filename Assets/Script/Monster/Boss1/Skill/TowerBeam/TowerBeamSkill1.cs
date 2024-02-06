using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBeamSkill1 : MonoBehaviour
{
    public Transform target; // 타겟 설정

    public float firingAngle = 45.0f; // 발사 각도
    public float projectileSpeed = 1f; // 발사체 속도

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Shield1"))
                {
                    target = col.gameObject.transform;
                    break;
                }
            }
        }
        if(target != null)
        {
            Launch();
        }
    }

    void Launch()
    {
        Vector3 targetPosition = target.position;
        Vector3 projectilePosition = transform.position;

        float targetDistance = Vector3.Distance(projectilePosition, targetPosition);
        float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / Physics.gravity.magnitude);

        Vector3 velocity = (targetPosition - projectilePosition).normalized * projectileVelocity;
        rb.velocity = velocity; // 발사체에 초기 속도 부여
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shield1"))
        {
            Destroy(gameObject, .5f);
            Destroy(other.gameObject);
        }
    }
}
