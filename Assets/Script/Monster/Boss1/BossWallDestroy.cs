using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallDestroy : MonoBehaviour
{
    public float growthDuration = 5f; // 커지는 시간 설정
    public float destructionDelay = 2f; // 터지기 전까지 대기 시간 설정

    private bool isExploding = false;

    void Start()
    {
        StartCoroutine(GrowAndExplode());
    }

    IEnumerator GrowAndExplode()
    {
        float startTime = Time.time;

        while (Time.time - startTime < growthDuration)
        {
            float t = (Time.time - startTime) / growthDuration;
            float newSize = Mathf.Lerp(0f, 8f, t); // 시작 크기(0)에서 목표 크기(10)로 선형 보간

            transform.localScale = new Vector3(newSize, 0.1f, newSize);
            yield return null;
        }

        // growthDuration 동안 크기가 커진 후에 실행되는 부분
        yield return new WaitForSeconds(destructionDelay);

        // 터지는 로직 추가
        Explode();
    }

    void Explode()
    {
        if (!isExploding)
        {
            isExploding = true;

            // 원하는 터지는 로직을 여기에 추가
            Debug.Log("장판이 터집니다!");

            // 예시로 바닥 장판을 파괴
            Destroy(gameObject);
        }
    }
}
