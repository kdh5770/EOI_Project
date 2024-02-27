using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Spawn : MonoBehaviour
{
    [Header("몬스터&플레이어 유무")]
    public Transform monster;
    public Transform player;
    [Header("보스&이펙트 소환 위치")]
    public Transform spawn_Boss;
    [Header("뮤턴트 프리팹")]
    public GameObject boss;
    [Header("뮤턴트 소환 시 발생하는 이펙트")]
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
