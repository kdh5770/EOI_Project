using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBeamSkill : MonoBehaviour
{
    public Transform target; // 타겟 설정

    public float firingAngle = 45.0f; // 발사 각도
    public float projectileSpeed = 10.0f; // 발사체 속도

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Launch();

        Collider[] colliders = Physics.OverlapSphere(transform.position, 30f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Shield"))
                {
                    target = col.gameObject.transform;
                    break;
                }
            }
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
