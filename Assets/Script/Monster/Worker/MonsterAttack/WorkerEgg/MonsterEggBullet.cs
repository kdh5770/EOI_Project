using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MonsterFSM;

public class MonsterEggBullet : MonoBehaviour
{
    public GameObject eggEFT;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(eggEFT, transform.position, Quaternion.identity);
            Destroy(obj, 2f);
            Destroy(this.gameObject);
        }
    }
}
