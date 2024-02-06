using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("DB Index_ID")]
    public int index_ID;

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
                GameObject mons = Instantiate(SpawnerPrefab, obj.transform.position, Quaternion.identity);
                MonsterStatus status = mons.GetComponent<MonsterStatus>();
                status.SpawnInit(Gamemanager.instance.databaseManager.monsterDataDic[index_ID]);
            }
        }
    }
}
