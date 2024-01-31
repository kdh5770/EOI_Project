using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CutSceneInteraction : Interaction
{
    [Header("Ÿ�Ӷ��� ������ �߰� �ϼ���")]
    public TimelineAsset timeLine;
    public override void Interact()
    {
        Gamemanager.instance.timeLineManager.SetInteraction(timeLine);
    }

}
