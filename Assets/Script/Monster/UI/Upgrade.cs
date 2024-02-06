using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float rotationSpeed = 50f; // ȸ�� �ӵ�

    public void Start()
    {
        StartCoroutine(UP());
    }

    IEnumerator UP()
    {
        while (true)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
