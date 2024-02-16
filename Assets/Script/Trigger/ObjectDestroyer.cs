using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private ObjectSpawner spawner;

    [Header("������ ������Ʈ ������")]
    [SerializeField]
    private GameObject Destroyobj;

    private void Start()
    {
        spawner = GetComponent<ObjectSpawner>();
    }

    void DestroyObject()
    {
        if (spawner.checkKill)
        {
            Destroy(this.gameObject);
        }
    }
}
