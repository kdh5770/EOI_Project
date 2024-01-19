using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergy : MonoBehaviour
{
    public GameObject pre;
    public Transform tf;

    public GameObject preObj;
    public void Energy()
    {
        if (preObj == null)
        {
            preObj = Instantiate(pre, tf.position, Quaternion.identity);
        }
    }
}
