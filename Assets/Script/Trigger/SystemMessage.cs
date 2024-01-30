using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessage : Interaction
{
    [Header("UI에 출력할 시스템 메세지를 적으세요")]
    [TextArea(3, 10)]
    public string messageText;
    public override void Interact()
    {
        Debug.Log(messageText);
    }
}
