using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger : MonoBehaviour
{

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
    public List<Interaction> interactions;
    public void InputPlayerTrigger()
    {
        if(interactions.Count > 0)
        {
            foreach(Interaction interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }


/*    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                InputPlayerTrigger();
            }
        }
    }*/
}
