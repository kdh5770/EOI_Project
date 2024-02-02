using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstEgg : MonsterStatus
{
    public GameObject boomEftPre;
    public GameObject boomPreObj;
    public GameObject target;

    public override void CalculateDamage(float _damage)
    {
        curHP -= _damage;
        if (curHP <= 0)
        {
            EggBoom();
        }
    }

    public void EggBoom()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        if (target != null)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
        }
        boomPreObj = Instantiate(boomEftPre, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomPreObj, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
            EggBoom();
        }
    }
}
