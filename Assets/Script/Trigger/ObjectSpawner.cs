using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("������ ������")]
    public GameObject SpawnerPrefab;
    [Header("������ ��ġ")]
    public List<Transform> spawnePos;
    public override void Interact()
    {
        if (SpawnerPrefab != null)
        {
            foreach (Transform trs in spawnePos)
            {
                Instantiate(SpawnerPrefab, trs);
                Debug.Log("������");
            }
        }
    }
}
