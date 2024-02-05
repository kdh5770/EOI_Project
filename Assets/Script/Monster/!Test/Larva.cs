using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonsterStatus
{
    [Header("������ ����Ʈ ������")]
    public GameObject boomEftPre;
    [Header("������ ����Ʈ")]
    public GameObject boomPreObj;
    [Header("������ ����Ʈ ��ġ")]
    public Transform boom;
    [Header("Ÿ��")]
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
