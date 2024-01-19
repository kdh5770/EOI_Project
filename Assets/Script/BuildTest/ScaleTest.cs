using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    [Header("목표 크기")]
    public float scaleValue;
    [Header("시간")]
    public float durationTime;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartScaling(scaleValue * Vector3.one, durationTime);
        }
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

        transform.localScale = targetScale;
    }
}
