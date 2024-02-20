using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : Interaction
{
    [Header("������Ʈ ��Ʈ ���� ��")]

    [Header("��ȣ�ۿ� - ��������")]
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
