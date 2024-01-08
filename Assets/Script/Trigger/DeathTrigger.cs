using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [Header("사망 or 없어질때 트리거")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;
    private void OnDestroy()
    {
        if(interactions != null )
        {
            foreach( Interaction interaction in interactions )
            {
                interaction.Interact();
            }
        }
    }
}
