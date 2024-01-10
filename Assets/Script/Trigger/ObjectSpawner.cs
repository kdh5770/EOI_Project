using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("스폰할 프리팹")]
    public GameObject SpawnerPrefab;
    [Header("스폰할 위치")]
    public List<Transform> spawnePos;
    public override void Interact()
    {
        if (SpawnerPrefab != null)
        {
            foreach (Transform trs in spawnePos)
            {
                Instantiate(SpawnerPrefab, trs);
                Debug.Log("리스폰");
            }
        }
    }
}
