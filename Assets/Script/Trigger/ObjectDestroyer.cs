using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [Header("������ ������Ʈ ������")]
    [SerializeField]
    private GameObject Destroyobj;

    private ObjectSpawner spawner;

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
