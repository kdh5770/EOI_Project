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

    public GameObject pittyHandPos;

    private void Start()
    {
        curHP = maxHP;
        Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, false);
    }

    public void TakeDamage(float _damage)
    {
        curHP -= ((int)(_damage - DEF));

        //Gamemanager.instance.characterUI.HandleHP(curHP, maxHP, true);

        if (curHP <= 0)
        {
            Debug.Log("플레이어 사망");
        }
    }
    public bool GetDie()
    {
        return (curHP <= 0);
    }
}
