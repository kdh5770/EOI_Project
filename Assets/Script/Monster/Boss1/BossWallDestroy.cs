using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallDestroy : MonoBehaviour
{
    public float growthDuration = 5f; // Ŀ���� �ð� ����
    public float destructionDelay = 2f; // ������ ������ ��� �ð� ����

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
            float newSize = Mathf.Lerp(0f, 8f, t); // ���� ũ��(0)���� ��ǥ ũ��(10)�� ���� ����

            transform.localScale = new Vector3(newSize, 0.1f, newSize);
            yield return null;
        }

        // growthDuration ���� ũ�Ⱑ Ŀ�� �Ŀ� ����Ǵ� �κ�
        yield return new WaitForSeconds(destructionDelay);

        // ������ ���� �߰�
        Explode();
    }

    void Explode()
    {
        if (!isExploding)
        {
            isExploding = true;

            // ���ϴ� ������ ������ ���⿡ �߰�
            Debug.Log("������ �����ϴ�!");

            // ���÷� �ٴ� ������ �ı�
            Destroy(gameObject);
        }
    }
}
