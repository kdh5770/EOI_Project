using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BossEnergyTower : MonoBehaviour
{
    public Transform target;
    public Transform tower2;
    public GameObject beam;
    public Transform beamTr;

    [Header("�� & ���� ��ġ")]
    public GameObject egg;
    public Transform eggPos;

    [Header("����Ʈ")]
    public GameObject eft;
    public Transform eftPos;

    public void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        gameObject.transform.LookAt(boss.transform);
        target = null;
        tower2 = null;

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

        Collider[] colliders_ = Physics.OverlapSphere(transform.position, 100f);

        if (colliders_.Length > 0)
        {
            foreach (Collider cols in colliders_)
            {
                if (cols.CompareTag("Tower2") )
                {
                    tower2 = cols.gameObject.transform;
                    break;
                }
            }
        }

        if (target != null && Input.GetKey(KeyCode.E) && tower2 == null)
        {
            if (Gamemanager.instance.player.GetComponent<CharacterInventory>().InvenObj[0] != null)
            {
                GameObject beam_ = Instantiate(beam, beamTr.transform.position, Quaternion.identity);
                GameObject egg_ = Instantiate(egg, eggPos.transform.position, Quaternion.identity);
                GameObject eft_ = Instantiate(eft, eftPos.transform.position, Quaternion.identity);
                Destroy(gameObject, 3f);
                Destroy(egg_, 3f);
                Destroy(eft_, 3f);
            }
        }
    }
}
