using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessage : Interaction
{
    [Header("UI�� ����� �ý��� �޼����� ��������")]
    public string messageText;
    public override void Interact()
    {
        Debug.Log(messageText);
    }
}
