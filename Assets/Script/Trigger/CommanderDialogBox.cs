using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CommanderDialogBox : Interaction
{
    [Header("UI에 출력할 대사를 적으세요")]
    [TextArea(3, 10)]
    public string dialogueText;

    public override void Interact()
    {
        string yellowText = "<color=yellow>" + dialogueText + "</color>";
        Gamemanager.instance.characterUI.CommanderDialogue(yellowText);
    }

}
