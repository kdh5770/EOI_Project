using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    [Header("총알에 히트 당했을 때 트리거")]

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (interactions.Count > 0)
            {
                foreach (Interaction interaction in interactions)
                {
                    interaction.Interact();
                }
            }

            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
