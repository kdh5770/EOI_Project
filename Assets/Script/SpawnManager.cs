using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public event Action AllKillAction;

    public bool allkill;
    public int killCount;
    Dictionary<string, GameObject> monsterPreDic = new Dictionary<string, GameObject>();

    private void Start()
    {
        killCount = 0;
    }

    public void SpawnMonster(int index_ID, GameObject _pre, List<GameObject> _spawnPos, bool _isCounting)
    {
        foreach (GameObject obj in _spawnPos)
        {
            GameObject mons = Instantiate(_pre, obj.transform.position, Quaternion.identity);
            MonsterStatus status = mons.GetComponent<MonsterStatus>();
            status.SpawnInit(Gamemanager.instance.databaseManager.monsterDataDic[index_ID], _isCounting);

            if(_isCounting)
            {
                killCount++;
            }
        }
    }

    public void AddKillCount()
    {
        killCount--;

        if(killCount <= 0)
        {
            allkill = true;
            AllKillAction?.Invoke();
            killCount = 0;
        }
        
    }
}
