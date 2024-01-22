using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeam : MonoBehaviour
{
    public Transform targetObject; // Ư�� ������Ʈ
    public float growthSpeed = 3.0f; // ũ�� ��ȭ �ӵ�
    public float maxScale = 10.0f; // �ִ� ũ��

    private void Update()
    {
        if (targetObject != null)
        {
            Vector3 directionToTarget = targetObject.position - transform.position;
            Vector3 normalizedDirection = directionToTarget.normalized;
            float newScale = Mathf.Min(transform.localScale.z + growthSpeed * Time.deltaTime, maxScale);

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScale);

            transform.rotation = Quaternion.LookRotation(normalizedDirection);
        }
    }
}
