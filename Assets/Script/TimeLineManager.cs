using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineManager : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public TimelineAsset cutScene;

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void SetInteraction(TimelineAsset _cutScene)
    {
        cutScene = _cutScene;
        playableDirector.stopped += StopTimeline;
        playableDirector.Play(cutScene);
    }

    public void StopTimeline(PlayableDirector _playableDirector)
    {
        playableDirector.stopped -= StopTimeline;
    }
}
