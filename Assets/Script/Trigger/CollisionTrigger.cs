using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [Header("Box에 부딪힐때 트리거")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;
    private void OnTriggerEnter(Collider other)
    {
        if(interactions.Count > 0)
        {
            foreach(Interaction interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }
}
