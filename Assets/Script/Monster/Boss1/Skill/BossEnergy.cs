using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergy : MonsterStatus
{
    public GameObject pre;
    public Transform tf;

    public GameObject preObj;
    public void Energy()
    {
        if(curHP <= maxHP * 0.5f)
        {
            preObj = Instantiate(pre, tf.transform.position, Quaternion.identity);
        }
    }
}
