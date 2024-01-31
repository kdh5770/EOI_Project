using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutSceneInteraction : Interaction
{
    [Header("타임라인 에셋을 추가 하세요")]
    public TimelineAsset timeLine;
    public PlayableDirector pd;

    public override void Interact()
    {
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
    }

}
