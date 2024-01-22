using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossWallDestroy : MonoBehaviour
{
    public float growthDuration = 5f; // 커지는 시간 설정
    public float destructionDelay = 0.5f; // 터지기 전까지 대기 시간 설정
    public float maxScale = 10f; // 최대 크기 설정

    public GameObject boom;

    private Coroutine growAndExplodeCoroutine;

    void Start()
    {
        // 코루틴 시작
        growAndExplodeCoroutine = StartCoroutine(GrowAndExplode());
    }

    IEnumerator GrowAndExplode()
    {
        float startTime = Time.time;

        while (Time.time - startTime < growthDuration)
        {
            float t = (Time.time - startTime) / growthDuration;
            float newSize = Mathf.Lerp(0f, maxScale, t); // 시작 크기(0)에서 목표 크기(maxScale)로 선형 보간

            transform.localScale = new Vector3(newSize, 0.1f, newSize);
            yield return null;
        }

        // growthDuration 동안 크기가 커진 후에 실행되는 부분
        yield return new WaitForSeconds(destructionDelay);

        // 최대 크기에 도달하면 부모 오브젝트를 파괴
        if (transform.localScale.x >= 6f)
        {
            Explode();
        }
    }

    void Explode()
    {
        // 코루틴 중지
        StopCoroutine(growAndExplodeCoroutine);

        // 부모 오브젝트 파괴
        Destroy(transform.root.gameObject);
        Instantiate(boom, transform.position, quaternion.identity);
    }
}
