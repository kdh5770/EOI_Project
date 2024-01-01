using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    bool isSpawn;
    void Start()
    {
        isSpawn = true;
        StartCoroutine(SpawnTriggerCourutin());
    }

    IEnumerator SpawnTriggerCourutin()
    {
        while (isSpawn)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
            foreach (Collider collider in colliders)
            {
                if(collider.CompareTag("Player"))
                {
                    Gamemanager.instance.spawnManager.SpawnMonsters();
                    isSpawn = false;
                    break;
                }
            }
            yield return null;

        }
    }
}
