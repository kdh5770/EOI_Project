using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BulletUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro BulletTxt;
    CharacterStateController characterStateController;


    private void Start()
    {
        BulletTxt=GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        HandleBulletUI();
    }


    void HandleBulletUI()
    {
        BulletTxt.text = characterStateController.curWeapon.Data.CurBullet.ToString()+"/"+characterStateController.curWeapon.Data.MaxBullet.ToString();

    }

}
