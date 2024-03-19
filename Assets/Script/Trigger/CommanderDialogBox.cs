using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CommanderDialogBox : Interaction
{
    [Header("UI�� ����� ��縦 ��������")]
    [TextArea(3, 10)]
    public string dialogueText;

    public override void Interact()
    {
        string yellowText = "<color=yellow>" + dialogueText + "</color>";
        Gamemanager.instance.characterUI.CommanderDialogue(yellowText);
    }

}
