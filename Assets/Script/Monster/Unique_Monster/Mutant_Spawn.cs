using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Spawn : MonoBehaviour
{
    [Header("����&�÷��̾� ����")]
    public Transform monster;
    public Transform player;
    [Header("����&����Ʈ ��ȯ ��ġ")]
    public Transform spawn_Boss;
    [Header("����Ʈ ������")]
    public GameObject boss;
    [Header("����Ʈ ��ȯ �� �߻��ϴ� ����Ʈ")]
    public GameObject eft;

    public void Update()
    {
        int monsterLayer = LayerMask.NameToLayer("Monster");
        string playerTag = "Player";

        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
        monster = null;
        player = null;

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.gameObject.layer == monsterLayer)
                {
                    monster = col.gameObject.transform;
                    break;
                }
                else if (col.gameObject.CompareTag(playerTag))
                {
                    player = col.gameObject.transform;
                }
            }
        }

        if (monster == null && player != null)
        {
            GameObject Mutant = Instantiate(boss, spawn_Boss.transform.position, Quaternion.identity);
            GameObject Eft = Instantiate(eft, spawn_Boss.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(Eft, 2f);
        }
    }
}
