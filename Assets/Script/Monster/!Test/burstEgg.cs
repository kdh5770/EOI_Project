using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstEgg : MonsterStatus
{
    public GameObject boomPre;
    public GameObject boomPre_;

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
        boomPre_ = Instantiate(boomPre, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomPre_, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            boomPre_ = Instantiate(boomPre, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(boomPre_, 4f);
        }
    }
}
