using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnTrigger : MonoBehaviour
{
    [Header("스폰할 몬스터")]
    public GameObject spawnMonster;

    [Header("스폰할 위치 - 복수 가능")]
    public Transform[] spawnPosition;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(Transform transform in spawnPosition)
            {
                Instantiate(spawnMonster, transform);
            }
        }
    }
}
