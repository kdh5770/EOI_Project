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
            // Ư�� ������Ʈ�� ���� ���� ���� ���
            Vector3 directionToTarget = targetObject.position - transform.position;

            // ũ�⸦ ������Ű�� ���� ���� ���� ����ȭ
            Vector3 normalizedDirection = directionToTarget.normalized;

            // ũ�⸦ ������Ű�� ���� ���ο� ������ ���
            float newScale = Mathf.Min(transform.localScale.z + growthSpeed * Time.deltaTime, maxScale);

            // ũ�� ����
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScale);

            // ���� ���͸� ������� ȸ��
            transform.rotation = Quaternion.LookRotation(normalizedDirection);
        }
    }
}
