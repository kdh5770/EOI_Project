using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [Header("Box�� �ε����� Ʈ����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
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
