using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("������ ������")]
    public GameObject SpawnerPrefab;
    [Header("������ ��ġ")]
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
