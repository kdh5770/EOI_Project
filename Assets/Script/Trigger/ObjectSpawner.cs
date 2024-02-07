using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    //[Header("DB Index_ID")]
    //public bool 
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
            foreach (GameObject obj in spawnePos)
            {
                if (monsterLyaer == LayerMask.LayerToName(SpawnerPrefab.layer))
                {
                    GameObject mons = Instantiate(SpawnerPrefab, obj.transform.position, Quaternion.identity);
                    MonsterStatus status = mons.GetComponent<MonsterStatus>();
                    status.SpawnInit(Gamemanager.instance.databaseManager.monsterDataDic[index_ID]);
                }
            }
        }
    }
}
