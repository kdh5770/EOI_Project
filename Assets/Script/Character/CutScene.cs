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
    [SerializeField]
    private Text ShakeSceneText;
    private CharacterInputSystem _input;
    // Start is called before the first frame update
    void Start()
    {
        pd=GetComponent<PlayableDirector>();
        _input=GetComponent<CharacterInputSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CutScene")
        {
            if (_input.interaction)
            {
                GetComponent<PlayerInput>().enabled = false;
                other.gameObject.SetActive(false);
                pd.played += CutSceneIsPlayed; // 수정된 부분
                pd.Play(Tl[0]);
            }
        }
    }

    void CutSceneIsPlayed(PlayableDirector director) // 수정된 함수 시그니처
    {
        if (!director.playableGraph.IsPlaying())
        {
            pd.played -= CutSceneIsPlayed; // 수정된 부분
            GetComponent<PlayerInput>().enabled = true;
        }
    }
    /*    private void OnTriggerStay(Collider other) // 컷씬이 재생 될 박스 콜라이더에 머물면서 
        {
            if (other.gameObject.tag == "CutScene") 
            {
                if (_input.interaction) // 상호작용 키 e 를 눌렀을 때
                {
                    GetComponent<PlayerInput>().enabled = false;
                    other.gameObject.SetActive(false);
                    pd.played += CutSceneIsPlayed;
                    pd.Play(Tl[0]);
                }
            }
        }

        void CutSceneIsPlayed(PlayableDirector director) // 컷씬이 재생완료됐을 때
        {
            if(!director.playableGraph.IsPlaying())
            {
                pd.played -= CutSceneIsPlayed;
                GetComponent<PlayerInput>().enabled = true;
            }
        }*/

}
