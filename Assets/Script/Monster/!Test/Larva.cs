using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonsterStatus
{
    public GameObject boomEftPre;
    public GameObject boomPreObj;
    public Transform boom;
    public GameObject target;
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
        gameObject.GetComponent<Collider>().enabled = false;

        if (target != null)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
        }
        boomPreObj = Instantiate(boomEftPre, boom.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomPreObj, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
            LarvaBoom();
        }
    }
}
