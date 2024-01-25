using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExitTrigger : MonoBehaviour
{
    [Header("박스 내부에서 나갈때")]

    [Header("상호작용 프리팹 넣기 - 복수가능")]
    public List<Interaction> interactions;
    private void OnTriggerStay(Collider other)
    {
        if (interactions.Count > 0)
        {
            foreach (Interaction interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }
}
