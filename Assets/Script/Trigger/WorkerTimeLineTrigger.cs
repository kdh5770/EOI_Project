using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerTimeLineTrigger : MonoBehaviour
{
    [Header("몬스터&플레이어 유무")]
    public Transform monster;
    public Transform player;

    [Header("워커 한마리 죽일 시 트리거")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;

    public void Update()
    {
        int monsterLayer = LayerMask.NameToLayer("Monster");
        string playerTag = "Player";

        Collider[] colliders = Physics.OverlapSphere(transform.position, 12f);
        monster = null;
        player = null;

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.gameObject.layer == monsterLayer)
                {
                    monster = col.gameObject.transform;
                }
                else if (col.gameObject.CompareTag(playerTag))
                {
                    player = col.gameObject.transform;
                }
            }
        }

        if (interactions.Count > 0 && !monster && player)
        {
            foreach (Interaction interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }
}