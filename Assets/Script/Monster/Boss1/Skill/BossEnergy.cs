using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnergy : MonoBehaviour
{
    public GameObject pre;
    public GameObject towerPre1;
    public GameObject towerPre2;
    public GameObject towerPre3;
    public GameObject shield;

    public Transform shieldTf;
    public Transform preTf;
    public Transform tower1;
    public Transform tower2;
    public Transform tower3;


    public GameObject preObj;

    public Slider hp;
    public void Energy()
    {
        if (preObj == null)
        {
            preObj = Instantiate(pre, preTf.position, Quaternion.identity);
            GameObject.Instantiate(towerPre1, tower1.transform.position, Quaternion.identity);
            GameObject.Instantiate(towerPre2, tower2.transform.position, Quaternion.identity);
            GameObject.Instantiate(towerPre3, tower3.transform.position, Quaternion.identity);
            GameObject.Instantiate(shield, shieldTf.transform.position, Quaternion.identity);
        }
    }
}
