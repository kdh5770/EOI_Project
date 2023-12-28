using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MonsterFSM;

public class MonsterEggBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
