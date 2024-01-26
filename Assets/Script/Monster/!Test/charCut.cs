using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class charCut : MonoBehaviour
{
    private PlayableDirector pd;
    public TimelineAsset[] ta;
    public GameObject image_1;
    public GameObject image_2;
    public WormFSM boss;

    private void Start()
    {
        pd = GetComponent<PlayableDirector>();
        pd.stopped += StopTimeline;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pd.Play(ta[0]);
            StartCoroutine(cut());
        }
    }
    public void StopTimeline(PlayableDirector _pd)
    {
        boss.ChangeState(MONSTER_STATE.TRACKING);
        pd.stopped -= StopTimeline;
    }

    IEnumerator cut()
    {
        yield return new WaitForSeconds(8.8f);
        image_1.SetActive(false);
        image_2.SetActive(false);
        gameObject.SetActive(false);
    }
}
