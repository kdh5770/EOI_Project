using System.Collections;
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

            // ���� ��ġ������ ���� ���� ���
            float terrainHeight = GetTerrainHeight(transform.position);

            // ���� ���̸� ����Ͽ� ���� ���� ũ�� ����
            transform.localScale = new Vector3(newSize, 0.1f, newSize) + Vector3.up * terrainHeight;
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
        Instantiate(boom, transform.position, Quaternion.identity);
    }

    float GetTerrainHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * 100f, Vector3.down, out hit, Mathf.Infinity))
        {
            return hit.point.y;
        }
        return 0f; // ��Ʈ���� ���� ��� �⺻���� 0
    }
}