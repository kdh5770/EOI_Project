using System;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    CharacterStateController controller;
    public event Action ActionAttack;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterStateController>();
    }

    public void EventAnimation()
    {
        ActionAttack?.Invoke();
    }

    public void EndAnimation() // ���� �ִϸ��̼� ����� ȣ���� �Լ�
    {
        Debug.Log("endAni");
        controller.ChangeState(CharacterSTATE.MOVE);
    }
}
