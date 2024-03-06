using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMessageBox : Interaction
{
    [Header("UI�� ����� ��縦 ��������")]
    [TextArea(3, 10)]
    public string dialogueText;

    public override void Interact()
    {
        Gamemanager.instance.characterUI.SetMissiontxt(dialogueText);
    }
}