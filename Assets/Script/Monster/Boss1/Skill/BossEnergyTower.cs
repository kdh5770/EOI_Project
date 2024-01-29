using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergyTower : MonoBehaviour
{
    public void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        gameObject.transform.LookAt(boss.transform);
    }
}
