using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : Interaction
{
    [Header("시간 입력")]
    public float timer;

    [Header("상호작용 - 복수가능")]
    public List<Interaction> interactions;

    public override void Interact()
    {
        if (interactions != null)
        {
            StartCoroutine(TimerInteraction());
        }
    }

    IEnumerator TimerInteraction()
    {
        yield return new WaitForSeconds(timer);

        foreach (Interaction _interact in interactions)
        {
            _interact.Interact();
        }
    }
}
