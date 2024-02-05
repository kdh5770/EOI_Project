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

    public float maxPotionGauge;
    public float curPotionGauge;

    public int curGoods;

    public event Action DeathAction;

    private void Start()
    {
        InitStatus();
    }
    void InitStatus()
    {
        curHP = maxHP;
        curCost = maxCost;
        DEF = 0;
        curPotionGauge = maxPotionGauge * .5f;
        curGoods = 0;


        Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, false);
        Gamemanager.instance.characterUI.HandleCost(curCost, maxCost);
        Gamemanager.instance.characterUI.HandlePotion(curPotionGauge, maxPotionGauge);
    }

    public void TakeDamage(float _damage)
    {
        curHP -= ((_damage - DEF));

        Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, true);

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

    public void ProductCost(float _cost)
    {
        curCost -= _cost;
        curCost = curCost <= 0 ? 0 : curCost;

        Gamemanager.instance.characterUI.HandleCost(curCost, maxCost);
    }


    public void TakePotion()
    {
        curPotionGauge += 10;
        if (curPotionGauge >= maxPotionGauge)
        {
            curPotionGauge = maxPotionGauge;
        }
        Gamemanager.instance.characterUI.HandlePotion(curPotionGauge, maxPotionGauge);
    }

    public void TakeGoods()
    {
        curGoods += 1;
    }

    public void UsingPortion()
    {
        curPotionGauge -= 10;
        curHP += 10;
    }
}
