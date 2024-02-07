using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("DB Index_ID")]
    public bool checkKill;

    [Header("DB Index_ID")]
    public int index_ID;

    [Header("������ ������")]
    public GameObject SpawnerPrefab;

    [Header("������ ��ġ")]
    public List<GameObject> spawnePos;

    private string monsterLyaer = "Monster";
    public override void Interact()
    {
        if (SpawnerPrefab != null)
        {
            if (monsterLyaer == LayerMask.LayerToName(SpawnerPrefab.layer))
            {
                Gamemanager.instance.spawnManager.SpawnMonster(index_ID, SpawnerPrefab, spawnePos, checkKill);
            }
            else
            {
                foreach (GameObject obj in spawnePos)
                {
                    Instantiate(SpawnerPrefab, obj.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
