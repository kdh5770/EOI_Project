using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHP;
    public float curHP;
    public float maxCost;
    public float curCost;

    public float ATK;
    public float DEF;
    public float baseSpeed;

    public float maxPortionGauge;
    public float curmaxPortionGauge;

    public event Action DeathAction;

    private void Start()
    {
        InitStatus();
    }

    public void TakeDamage(float _damage)
    {
        curHP -= ((_damage - DEF));

        Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, true);

        if (curHP <= 0)
        {
            //ĳ���� ����� ��ϵ� �̺�Ʈ ����
            DeathAction?.Invoke();
        }
    }

    public void ProductCost(float _cost)
    {
        curCost -= _cost;
        curCost = curCost <= 0 ? 0 : curCost;

        Gamemanager.instance.characterUI.HandleCost(curCost, maxCost);
    }

    public bool GetDie()
    {
        return (curHP <= 0);
    }

    void InitStatus()
    {
        curHP = maxHP;
        curCost = maxCost;
        DEF = 0;

        Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, false);
        Gamemanager.instance.characterUI.HandleCost(curCost, maxCost);
    }
}
