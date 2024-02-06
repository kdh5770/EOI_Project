using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonsterStatus
{
    [Header("터지는 이펙트 프리팹")]
    public GameObject boomEftPre;
    [Header("생성된 이펙트")]
    public GameObject boomPreObj;
    [Header("생성된 이펙트 위치")]
    public Transform boom;
    [Header("타겟")]
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
        //gameObject.GetComponent<Collider>().enabled = false;

        Debug.Log("asd");
        boomPreObj = Instantiate(boomEftPre, boom.transform.position, Quaternion.identity);
        Destroy(boomPreObj, 2f);
        Destroy(gameObject);

        if (target != null)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
        }
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
