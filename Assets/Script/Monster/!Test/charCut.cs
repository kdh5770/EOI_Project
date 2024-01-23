using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class charCut : MonoBehaviour
{
    private PlayableDirector pd;
    public TimelineAsset[] ta;
    public GameObject image;
    private void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pd.Play(ta[0]);
            StartCoroutine(cut());
        }
    }

    IEnumerator cut()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
}
