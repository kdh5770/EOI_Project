using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEnergyTower : MonoBehaviour
{
    public Transform target;
    public GameObject beam;
    public Transform beamTr;
    public void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        gameObject.transform.LookAt(boss.transform);
    }
    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject.transform;
                    break;
                }
            }
        }

        if (target != null && Input.GetKey(KeyCode.E))
        {
            Instantiate(beam, beamTr.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
