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



    

    private void OnTriggerStay(Collider other) // 컷씬이 재생 될 박스 콜라이더에 머물면서 
    {
        if (other.gameObject.tag == "CutScene") 
        {
            if (_input.interaction) // 상호작용 키 e 를 눌렀을 때
            {

                other.gameObject.SetActive(false);
                pd.Play(Tl[0]);
                GetComponent<PlayerInput>().enabled = false; // 플레이어 이동불가상태 만들기
                other.gameObject.SetActive(false);;
                pd.Play(Tl[0]);
                StartCoroutine(CutSceneIsPlayed()); // 코루틴 사용 11초 후 플레이어 이동 재개

            }
        }
    }


    IEnumerator CutSceneIsPlayed() 
    {
        yield return new WaitForSeconds(11f);
        GetComponent<PlayerInput>().enabled = true;
    }


}
