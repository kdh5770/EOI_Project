using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScale : MonoBehaviour
{
    [Header("��ǥ ũ��")]
    public float scaleValue;
    [Header("�ð�")]
    public float durationTime;
    [Header("�ִ� ũ��")]
    public float maxScale;
    [Header("����")]
    public GameObject preBomm; //������ ������Ʈ
    public float effectTimer;

    private void Start()
    {
        StartScaling(scaleValue * Vector3.one, durationTime);
    }

    private void Update()
    {
        // �߰����� �����ϸ� �� ���� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
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

        // �������� ��ǥ ũ�⿡ �����ϸ� ���ο� ������Ʈ ����
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
