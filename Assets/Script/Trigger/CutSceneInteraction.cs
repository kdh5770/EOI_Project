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
    [Header("타임라인에 사용된 오브젝트 파괴")]
    public List<GameObject> gameobjects;

    public float boss; // 정훈아 이거 왜있냐? ㅇㅅㅇ;;

    public override void Interact()
    {
        //Time.timeScale = 0;
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        pd.stopped += OnTimelineStopped; // 타임라인이 끝날 때 재개되도록 설정
    }

    private void OnTimelineStopped(PlayableDirector director) // 타임라인이 끝날 때 호출되는 메서드
    {
        foreach (GameObject interaction in gameobjects)
        {
            Destroy(interaction.gameObject);
        }
        //Time.timeScale = 1;

        pd.stopped -= OnTimelineStopped; // 이벤트 리스너를 제거
    }
}