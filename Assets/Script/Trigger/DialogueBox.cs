using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : Interaction
{
    [Header("UI�� ����� ��縦 ��������")]
    [TextArea(3, 10)]
    public string dialogueText;

    public override void Interact()
    {
        string yellowText = "<color=yellow>" + dialogueText + "</color>";
        Gamemanager.instance.characterUI.SetDialogue(yellowText);
    }
}