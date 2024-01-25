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

        if(dist<=3f) // �÷��̾�� �� ������ �Ÿ��� 10 ����, E ������� ǥ�� ���̱�
        {
            InterAction_Btn.SetActive(true);
        }
        else if(dist>3f) // �÷��̾�� �� ���� �Ÿ� 10 �ʰ�, E ǥ�� ����
        {
            InterAction_Btn.SetActive(false);
        }
    }
}
