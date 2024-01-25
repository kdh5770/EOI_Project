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



    

    private void OnTriggerStay(Collider other) // �ƾ��� ��� �� �ڽ� �ݶ��̴��� �ӹ��鼭 
    {
        if (other.gameObject.tag == "CutScene") 
        {
            if (_input.interaction) // ��ȣ�ۿ� Ű e �� ������ ��
            {

                other.gameObject.SetActive(false);
                pd.Play(Tl[0]);
                GetComponent<PlayerInput>().enabled = false; // �÷��̾� �̵��Ұ����� �����
                other.gameObject.SetActive(false);;
                pd.Play(Tl[0]);
                StartCoroutine(CutSceneIsPlayed()); // �ڷ�ƾ ��� 11�� �� �÷��̾� �̵� �簳

            }
        }
    }


    IEnumerator CutSceneIsPlayed() 
    {
        yield return new WaitForSeconds(11f);
        GetComponent<PlayerInput>().enabled = true;
    }


}
