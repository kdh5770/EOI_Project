using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonsterStatus
{
    public GameObject boomEft;
    public GameObject boomEft_;
    public Transform boom;

    public override void CalculateDamage(float _damage)
    {
        curHP -= _damage;
        if (curHP <= 0)
        {
            LarvaBoom();
        }
    }

    public void LarvaBoom()
    {
        boomEft_ = Instantiate(boomEft, boom.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomEft_, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            boomEft_ = Instantiate(boomEft, boom.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(boomEft_, 2f);
        }
    }
}
