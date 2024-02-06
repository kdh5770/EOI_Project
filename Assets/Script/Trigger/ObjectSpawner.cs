using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("스폰할 프리팹")]
    public GameObject SpawnerPrefab;
    [Header("스폰할 위치")]
    public List<GameObject> spawnePos;
    public override void Interact()
    {
        if (SpawnerPrefab != null)
        {
            foreach (GameObject obj in spawnePos)
            {
                Instantiate(SpawnerPrefab, obj.transform.position, Quaternion.identity);
            }
        }
    }
}
