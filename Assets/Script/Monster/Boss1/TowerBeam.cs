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
            // 특정 오브젝트를 향해 방향 벡터 계산
            Vector3 directionToTarget = targetObject.position - transform.position;

            // 크기를 증가시키기 위한 방향 벡터 정규화
            Vector3 normalizedDirection = directionToTarget.normalized;

            // 크기를 증가시키기 위한 새로운 스케일 계산
            float newScale = Mathf.Min(transform.localScale.z + growthSpeed * Time.deltaTime, maxScale);

            // 크기 조절
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScale);

            // 방향 벡터를 기반으로 회전
            transform.rotation = Quaternion.LookRotation(normalizedDirection);
        }
    }
}
