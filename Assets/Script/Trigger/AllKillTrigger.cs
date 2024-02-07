using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllKillTrigger : Interaction
{
    [Header("������ ���Ͱ� ��� �׾�����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
    public List<Interaction> interactions;
    
    public void EventAllKill()
    {
        if (interactions.Count > 0)
        {
            foreach (Interaction interaction in interactions)
            {
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
