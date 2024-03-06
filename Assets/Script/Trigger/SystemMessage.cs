using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SystemMessage : Interaction
{
    [Header("UI�� ����� �ý��� �޼����� ��������")]
    [TextArea(3, 10)]
    public string messageText;
    public override void Interact()
    {
        Gamemanager.instance.characterUI.SetSystemMsgtxt(messageText);
    }
}
