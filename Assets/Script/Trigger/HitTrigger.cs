using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : Interaction
{
    [Header("������ ���Ͱ� ��� �׾�����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
    public List<GameObject> gameobjects;

    public void EventAllKill()
    {
        if (gameobjects.Count > 0)
        {
            foreach (GameObject go in gameobjects)
            {
                Interaction interaction = go.GetComponent<Interaction>();
                if(interaction != null)
                {
                    interaction.Interact();
                }
                interaction.Interact();
            }
        }
        Gamemanager.instance.spawnManager.AllKillAction -= EventAllKill;
    }

    public override void Interact()
    {
        Gamemanager.instance.spawnManager.AllKillAction += EventAllKill;
    }
}
