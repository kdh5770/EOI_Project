using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossWallDestroy : MonoBehaviour
{
    public float growthDuration = 5f; // Ŀ���� �ð� ����
    public float destructionDelay = 0.5f; // ������ ������ ��� �ð� ����
    public float maxScale = 10f; // �ִ� ũ�� ����

    public GameObject boom;

    private Coroutine growAndExplodeCoroutine;

    void Start()
    {
        // �ڷ�ƾ ����
        growAndExplodeCoroutine = StartCoroutine(GrowAndExplode());
    }

    IEnumerator GrowAndExplode()
    {
        float startTime = Time.time;

        while (Time.time - startTime < growthDuration)
        {
            float t = (Time.time - startTime) / growthDuration;
            float newSize = Mathf.Lerp(0f, maxScale, t); // ���� ũ��(0)���� ��ǥ ũ��(maxScale)�� ���� ����

            transform.localScale = new Vector3(newSize, 0.1f, newSize);
            yield return null;
        }

        // growthDuration ���� ũ�Ⱑ Ŀ�� �Ŀ� ����Ǵ� �κ�
        yield return new WaitForSeconds(destructionDelay);

        // �ִ� ũ�⿡ �����ϸ� �θ� ������Ʈ�� �ı�
        if (transform.localScale.x >= 6f)
        {
            Explode();
        }
    }

    void Explode()
    {
        // �ڷ�ƾ ����
        StopCoroutine(growAndExplodeCoroutine);

        // �θ� ������Ʈ �ı�
        Destroy(transform.root.gameObject);
        Instantiate(boom, transform.position, quaternion.identity);
    }
}
