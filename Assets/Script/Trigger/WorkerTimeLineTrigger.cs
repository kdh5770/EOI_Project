using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerTimeLineTrigger : MonoBehaviour
{
    [Header("����&�÷��̾� ����")]
    public Transform monster;
    public Transform player;

    [Header("��Ŀ �Ѹ��� ���� �� Ʈ����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
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