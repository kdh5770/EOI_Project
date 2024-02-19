using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStructure : MonsterStatus
{
    public GameObject boomEftPre;
    public GameObject boomPreObj;

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

        boomPreObj = Instantiate(boomEftPre, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomPreObj, 2f);
    }
}
