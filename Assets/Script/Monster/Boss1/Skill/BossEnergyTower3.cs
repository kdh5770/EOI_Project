using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEnergyTower3 : CharacterInventory
{
    public Transform target;
    public GameObject beam;
    public Transform beamTr;

    [Header("¾Ë & ³öµÑ À§Ä¡")]
    public GameObject egg;
    public Transform eggPos;

    [Header("ÀÌÆåÆ®")]
    public GameObject eft;
    public Transform eftPos;

    public void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        gameObject.transform.LookAt(boss.transform);
        target = null;
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
            if (Gamemanager.instance.player.GetComponent<CharacterInventory>().InvenObj[2] != null)
            {
                Instantiate(beam, beamTr.transform.position, Quaternion.identity);
                GameObject egg_ = Instantiate(egg, eggPos.transform.position, Quaternion.identity);
                GameObject eft_ = Instantiate(eft, eftPos.transform.position, Quaternion.identity);
                Destroy(gameObject, 3f);
                Destroy(egg_, 3f);
            }
        }
    }
}