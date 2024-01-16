using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct WeaponData
{
    public int Damage;
    public int MaxBullet;
    public int CurBullet;
    public float ShotDelay;
    
    //public GameObject WeaponFireFlash; // �� �� �� �ѱ����� ������ ��? ��ȭ���� �߰��ؾ���. ��ȭ�� ��ġ�� �߰��ؾ���.
}

public abstract class WeaponTable: MonoBehaviour
{
    public WeaponData Data;
    private CharacterInputSystem _input;
    private float restTime = 0f;

    private void Start()
    {
        _input = GetComponent<CharacterInputSystem>();
    }


    public abstract void Initsetting();

    public virtual void Using()
    {
        if(_input.aim)
        {
            restTime += Time.deltaTime;
            if(_input.shoot&&Data.ShotDelay<=restTime&&Data.CurBullet>=0)
            {
                Data.CurBullet--;
                restTime = 0f;
            }
        }
    }
}