using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Spawn : MonoBehaviour
{
    Transform monster;
    [Header("����&����Ʈ ��ȯ ��ġ")]
    public Transform spawn_Boss;
    [Header("����Ʈ ������")]
    public GameObject boss;
    [Header("����Ʈ ��ȯ �� �߻��ϴ� ����Ʈ")]
    public GameObject eft;

    public void Update()
    {
        int monsterLayer = LayerMask.NameToLayer("Monster");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
        monster = null;

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.gameObject.layer == monsterLayer)
                {
                    monster = col.gameObject.transform;
                    break;
                }
            }
        }

        if (monster == null)
        {
            GameObject Mutant = Instantiate(boss, spawn_Boss.transform.position, Quaternion.identity);
            GameObject Eft = Instantiate(eft, spawn_Boss.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(Eft, 2f);
        }
    }
}
