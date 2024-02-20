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
    public float asd;

    public override void Interact()
    {
        //Time.timeScale = 0f; // 타임라인 실행 전에 모든 동작을 일시 정지
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        while(true)
        {
            asd += Time.deltaTime;
        }
        //pd.stopped += OnTimelineStopped; // 타임라인이 끝날 때 재개되도록 설정
    }

    private void OnTimelineStopped(PlayableDirector director) // 타임라인이 끝날 때 호출되는 메서드
    {
        Time.timeScale = 1f; // 일시 정지를 해제하고 원래의 시간으로 복귀
        pd.stopped -= OnTimelineStopped; // 이벤트 리스너를 제거
    }
}
