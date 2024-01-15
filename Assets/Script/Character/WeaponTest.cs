using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct WeaponData
{
    public int Damage;
    public int MaxBullet;
    public int CurBullet;
    public float ShotDelay;
}

public abstract class WeaponTest:MonoBehaviour
{
    public WeaponData Data;
    private CharacterInputSystem _input;

    private void Start()
    {
        _input = GetComponent<CharacterInputSystem>();
    }


    public abstract void Initsetting();

    public virtual void Using()
    {
        if(_input.aim&&_input.shoot)
        {

        }
    }
}