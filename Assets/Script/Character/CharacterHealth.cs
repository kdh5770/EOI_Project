using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP;
    public int curHP;
    public int maxCost;
    public int curCost;

    public float ATK;
    public float DEF;
    public float baseSpeed;

    public float maxPortionGauge;
    public float curmaxPortionGauge;

    public event Action DeathAction;

    private void Start()
    {
        InitStatus();
        //Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, false);
    }

    public void TakeDamage(float _damage)
    {
        curHP -= ((int)(_damage - DEF));

       // Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, true);

        if (curHP <= 0)
        {
            //캐릭터 사망시 등록된 이벤트 실행
            DeathAction?.Invoke();
        }
    }

    public bool GetDie()
    {
        return (curHP <= 0);
    }

    void InitStatus()
    {
        curHP = maxHP;
        curCost = maxCost;
    }
}
