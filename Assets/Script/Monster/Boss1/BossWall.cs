using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    public int hitCount = 5;


    public void BossWall_asd()
    {
        hitCount--;
        if (hitCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
