using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaBoomTf : MonoBehaviour
{
    public Transform target;

    public void Start()
    {
        StartCoroutine(Look());
    }

    IEnumerator Look()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject.transform;
                    break;
                }
            }
            gameObject.transform.LookAt(target);
            yield return null;
        }
    }
}
