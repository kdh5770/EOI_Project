using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EggTouched : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    [SerializeField]
    private float dist;
    [SerializeField]
    private GameObject InterAction_Btn;


    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(character.position, this.transform.position);

        if(dist<=3f) // 플레이어와 알 사이의 거리가 10 이하, E 누르라는 표시 보이기
        {
            InterAction_Btn.SetActive(true);
        }
        else if(dist>3f) // 플레이어와 알 사이 거리 10 초과, E 표시 끄기
        {
            InterAction_Btn.SetActive(false);
        }
    }
}
