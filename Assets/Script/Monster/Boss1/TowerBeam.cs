using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeam : MonoBehaviour
{
    public Transform targetObject; // 특정 오브젝트
    public float growthSpeed = 3.0f; // 크기 변화 속도
    public float maxScale = 10.0f; // 최대 크기

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
