using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [Header("��� or �������� Ʈ����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
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
