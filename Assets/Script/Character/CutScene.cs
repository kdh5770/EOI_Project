using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    private PlayableDirector pd;
    public TimelineAsset[] Tl;
    [SerializeField]
    private Text ShakeSceneText;
    private CharacterInputSystem _input;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        pd=GetComponent<PlayableDirector>();
        _input=GetComponent<CharacterInputSystem>();
        _animator=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other) // �ƾ��� ��� �� �ڽ� �ݶ��̴��� �ӹ��鼭 
    {
        if (other.gameObject.tag == "CutScene") 
        {
            if (_input.interaction) // ��ȣ�ۿ� Ű e �� ������ ��
            {
                other.gameObject.SetActive(false);
                pd.Play(Tl[0]);
            }
        }
    }
}
