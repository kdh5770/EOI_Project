using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("������ ������")]
    public GameObject SpawnerPrefab;
    [Header("������ ��ġ")]
    public Transform[] spawnePos;
    public override void Interact()
    {
        if (SpawnerPrefab != null)
        {
            foreach (Transform pos in spawnePos)
            {
                Instantiate(SpawnerPrefab, pos);
            }
        }
    }
}
