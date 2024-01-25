using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStayTrigger : MonoBehaviour
{
    [Header("�ڽ� ���ο� ������")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ��������")]
    public List<Interaction> interactions;
    private void OnTriggerStay(Collider other)
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
