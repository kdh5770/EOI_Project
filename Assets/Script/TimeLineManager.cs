using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public TimelineAsset cutScene;


    public void SetInteraction(PlayableDirector _pd, TimelineAsset _cutScene)
    {
        playableDirector = _pd;
        cutScene = _cutScene;
        playableDirector.playableAsset = cutScene;
        playableDirector.stopped += StopTimeline;
        playableDirector.Play(cutScene);
    }

    public void StopTimeline(PlayableDirector _playableDirector)
    {
        playableDirector.stopped -= StopTimeline;
        playableDirector.enabled = false;
    }
}
