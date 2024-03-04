using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : Interaction
{
    [Header("제거할 오브젝트 스포너")]
    private ObjectSpawner spawner;

    /*    [SerializeField]
        private GameObject Destroyobj;


        */
    private void Start()
    {
        spawner = GetComponent<ObjectSpawner>();
    }

    public override void Interact()
    {
        if (Gamemanager.instance.spawnManager.allkill)
        {
            Destroy(this.gameObject);
        }
    }
}
