using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text BulletTxt;
    private Gamemanager gamemanager;
    private CharacterStateController characterStateController;


    private void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
    }

    private void Update()
    {
        HandleBulletUI();
        
    }


    void HandleBulletUI()
    {
        characterStateController = gamemanager.player.GetComponent<CharacterStateController>();
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