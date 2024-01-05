using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnTrigger : MonoBehaviour
{
    [Header("������ ����")]
    public GameObject spawnMonster;

    [Header("������ ��ġ - ���� ����")]
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
