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
                pd.played += CutSceneIsPlayed; // ������ �κ�
                pd.Play(Tl[0]);
            }
        }
    }

    void CutSceneIsPlayed(PlayableDirector director) // ������ �Լ� �ñ״�ó
    {
        if (!director.playableGraph.IsPlaying())
        {
            pd.played -= CutSceneIsPlayed; // ������ �κ�
            GetComponent<PlayerInput>().enabled = true;
        }
    }
    /*    private void OnTriggerStay(Collider other) // �ƾ��� ��� �� �ڽ� �ݶ��̴��� �ӹ��鼭 
        {
            if (other.gameObject.tag == "CutScene") 
            {
                if (_input.interaction) // ��ȣ�ۿ� Ű e �� ������ ��
                {
                    GetComponent<PlayerInput>().enabled = false;
                    other.gameObject.SetActive(false);
                    pd.played += CutSceneIsPlayed;
                    pd.Play(Tl[0]);
                }
            }
        }

        void CutSceneIsPlayed(PlayableDirector director) // �ƾ��� ����Ϸ���� ��
        {
            if(!director.playableGraph.IsPlaying())
            {
                pd.played -= CutSceneIsPlayed;
                GetComponent<PlayerInput>().enabled = true;
            }
        }*/

}
