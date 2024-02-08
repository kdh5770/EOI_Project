using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Boom : MonoBehaviour
{
    public void Start()
    {
        Destroy();
    }
    private void Destroy()
    {
        //타워 1~3
        GameObject tower1 = GameObject.FindGameObjectWithTag("Tower1");
        GameObject tower2 = GameObject.FindGameObjectWithTag("Tower2");
        GameObject tower3 = GameObject.FindGameObjectWithTag("Tower3");
        if (tower1 != null)
        {
            Destroy(tower1);
        }
        if (tower2 != null)
        {
            Destroy(tower2);
        }
        if (tower3 != null)
        {
            Destroy(tower3);
        }

        //보호막 1~3
        GameObject Shield1 = GameObject.FindGameObjectWithTag("Shield1");
        GameObject Shield2 = GameObject.FindGameObjectWithTag("Shield2");
        GameObject Shield3 = GameObject.FindGameObjectWithTag("Shield3");
        if (Shield1 != null)
        {
            Destroy(Shield1);
        }
        if (Shield2 != null)
        {
            Destroy(Shield2);
        }
        if (Shield3 != null)
        {
            Destroy(Shield3);
        }
    }
}
