using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public List<Transform> transforms;
    public GameObject monsterPre;

    public void SpawnMonster()
    {
        foreach (Transform spawnPos in transforms)
        {
            Instantiate(monsterPre, spawnPos);
        }
    }
}
