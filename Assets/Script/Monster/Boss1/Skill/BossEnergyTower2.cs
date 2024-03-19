using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEnergyTower2 : CharacterInventory
{
    public Transform target;
    public Transform tower3;
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
                }
                else if (!col.CompareTag("Player"))
                {
                    target = null;
                }
            }
        }

        Collider[] colliders_ = Physics.OverlapSphere(transform.position, 100f);

        if (colliders_.Length > 0)
        {
            foreach (Collider cols in colliders_)
            {
                if (cols.CompareTag("Tower3"))
                {
                    tower3 = cols.gameObject.transform;
                }
                else if (!cols.CompareTag("Tower3"))
                {
                    tower3 = null;
                }
            }
        }

        if (target != null && Input.GetKey(KeyCode.E) && tower3 == null)
        {
            if (Gamemanager.instance.player.GetComponent<CharacterInventory>().InvenObj[1] != null)
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
