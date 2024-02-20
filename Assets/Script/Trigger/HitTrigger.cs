using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : Interaction
{
    [Header("오브젝트 히트 했을 시")]

    [Header("상호작용 - 복수가능")]
    public List<Interaction> interactions;

    public override void Interact()
    {
        if (interactions != null)
        {
            StartCoroutine(HitInteraction());
        }
    }

    IEnumerator HitInteraction()
    {
        yield return null;

        foreach (Interaction _interact in interactions)
        {
            _interact.Interact();
        }
    }
}
