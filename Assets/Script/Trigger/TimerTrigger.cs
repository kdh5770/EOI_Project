using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : Interaction
{
    [Header("�ð� �Է�")]
    public float timer;

    [Header("��ȣ�ۿ� - ��������")]
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
