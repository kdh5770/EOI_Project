using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllKillTrigger : Interaction
{
    [Header("스폰한 몬스터가 모두 죽었을때")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
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
