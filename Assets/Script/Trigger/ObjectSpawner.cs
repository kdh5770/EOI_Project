using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Interaction
{
    [Header("DB Index_ID")]
    public bool checkKill;

    [Header("DB Index_ID")]
    public int index_ID;

    [Header("스폰할 프리팹")]
    public List<GameObject> SpawnerPrefabs = new List<GameObject>();

    [Header("스폰할 위치")]
    public List<GameObject> spawnePos;

    private string monsterLyaer = "Monster";
    int i = 0;


    public override void Interact()
    {
        if (SpawnerPrefabs != null)
        {
            if (monsterLyaer == LayerMask.LayerToName(SpawnerPrefabs[i].layer))
            {
                Gamemanager.instance.spawnManager.SpawnMonster(index_ID, SpawnerPrefabs[i], spawnePos, checkKill);
            }
            else
            {
                foreach (GameObject obj in spawnePos)
                {
                    Instantiate(SpawnerPrefabs[i], obj.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public void DestroyPrefab()
    {
        if(checkKill)
        {
            Destroy(SpawnerPrefabs[i]);
            i++;
        }
    }

}
