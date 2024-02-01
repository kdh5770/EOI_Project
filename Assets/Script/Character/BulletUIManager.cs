using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text BulletTxt;
    private CharacterStateController characterStateController;


    private void Start()
    {
 
    }

    private void Update()
    {
        HandleBulletUI();
    }


    void HandleBulletUI()
    {

        if (characterStateController != null)
        {
            BulletTxt.text = characterStateController.curWeapon.Data.CurBullet.ToString() + "/" + characterStateController.curWeapon.Data.MaxBullet.ToString();
        }
        else
        {
            Debug.Log("³Î");
        }
    }

}
