using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CutScene : MonoBehaviour
{
    private PlayableDirector pd;
    public TimelineAsset[] Tl;
    public CharacterStateController player;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        player=GetComponent<CharacterStateController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pd.Play(Tl[0]);
            player.enabled = false; // 플레이어 이동불가상태 만들기
            //other.gameObject.SetActive(false); ;
            StartCoroutine(CutSceneIsPlayed()); // 코루틴 사용 11초 후 플레이어 이동 재개
        }
    }


    IEnumerator CutSceneIsPlayed()
    {
        yield return new WaitForSeconds(11f);
        player.enabled = true;
    }


}
