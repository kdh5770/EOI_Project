using System;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    CharacterController controller;
    public event Action ActionAttack;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterController>();
    }

    public void EventAnimation()
    {
        ActionAttack?.Invoke();
    }

    public void EndAnimation() // ���� �ִϸ��̼� ����� ȣ���� �Լ�
    {
        
    }
}
