using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> monsterList;
    public List<Transform> spawnTransformList;

    public void SpawnMonsters()
    {
        foreach(Transform trans in spawnTransformList)
        {
            Instantiate(monsterList[0], trans.position, Quaternion.identity);
        }
    }
}
