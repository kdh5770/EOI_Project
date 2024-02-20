using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    [Header("�Ѿ˿� ��Ʈ ������ �� Ʈ����")]

    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
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
