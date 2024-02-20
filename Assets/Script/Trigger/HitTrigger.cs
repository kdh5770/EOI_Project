using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : Interaction
{
    [Header("스폰한 몬스터가 모두 죽었을때")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
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
