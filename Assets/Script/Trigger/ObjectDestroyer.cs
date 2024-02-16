using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private ObjectSpawner spawner;

    [Header("제거할 오브젝트 스포너")]
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
