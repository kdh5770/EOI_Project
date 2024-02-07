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
    [Header("������ ������ ������ ����")]
    public GameObject spawnPre;
    [Header("������ ���� ��ġ")]
    public Transform spawnPos;

    public override void CalculateDamage(float _damage)
    {
        base.CalculateDamage(_damage);
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
       
        if (target != null)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
        }
        Destroy(boomPreObj, 2f);
    }

    private void OnDestroy()
    {
        Instantiate(spawnPre, spawnPos.position, Quaternion.identity);
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
