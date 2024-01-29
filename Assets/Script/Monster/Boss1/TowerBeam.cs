using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeam : MonoBehaviour
{
    public Transform targetObject; // Ư�� ������Ʈ
    public float growthSpeed = 3.0f; // ũ�� ��ȭ �ӵ�
    public GameObject beamObj;
    public GameObject end;

    private bool collided = false;

    private void Update()
    {
        if (!collided && targetObject != null)
        {
            Vector3 directionToTarget = targetObject.position - transform.position;
            Vector3 normalizedDirection = directionToTarget.normalized;


            beamObj.transform.localScale += Vector3.forward * growthSpeed * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(normalizedDirection);

            //Vector3 rayDir = (beamObj.transform.position - transform.position).normalized;
            if(Physics.Linecast(transform.position, end.transform.position, out RaycastHit hit))
            {
                Debug.DrawLine(transform.position, end.transform.position);
                if (hit.collider.CompareTag("Monster"))
                {
                    collided = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            collided = true;
        }
    }
}
