using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScale : MonoBehaviour
{
    [Header("목표 크기")]
    public float scaleValue;
    [Header("시간")]
    public float durationTime;
    [Header("최대 크기")]
    public float maxScale;
    [Header("터짐")]
    public GameObject preBomm; //프리팹 오브젝트
    public float effectTimer;

    private void Start()
    {
        StartScaling(scaleValue * Vector3.one, durationTime);
    }

    private void Update()
    {
        // 추가적인 스케일링 및 스폰 로직을 여기에 추가할 수 있습니다.
    }

    public void StartScaling(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleOverTime(targetScale, duration));
    }

    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 originalScale = transform.localScale;
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // 스케일이 목표 크기에 도달하면 새로운 오브젝트 생성
        if (transform.localScale.magnitude >= maxScale)
        {
            SpawnNewObject();
        }
    }

    void SpawnNewObject()
    {
        GameObject preBomm_ = Instantiate(preBomm, transform.position, Quaternion.identity);
        Destroy(preBomm_, effectTimer);
        Destroy(gameObject);
    }
}
