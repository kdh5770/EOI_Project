using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unique_Health : MonsterStatus
{
    [Header("체력비례 대사")]
    public GameObject hp100;
    public GameObject hp75;
    public GameObject hp50_1;
    public GameObject hp50_2;
    public GameObject hp50_3;
    [Header("대사 치는 시간")]
    float dialogue = 0;
    [Header("대사 치는 순서")]
    int count = 1;

    public override void CalculateDamage(float _damage)
    {
        base.CalculateDamage(_damage);
    }

    public void Start()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        while(true)
        {
            if (curHP == maxHP && count == 1)
            {
                hp100.SetActive(true);
                dialogue += Time.deltaTime;
                if (dialogue >= 3f)
                {
                    hp100.SetActive(false);
                    dialogue = 0;
                    count++;
                }
            }

            if (curHP <= maxHP * .75f && count == 2)
            {
                hp75.SetActive(true);
                dialogue += Time.deltaTime;
                if (dialogue >= 3f)
                {
                    hp75.SetActive(false);
                    dialogue = 0;
                    count++;
                }
            }

            if (curHP <= maxHP * .5f && count == 3)
            {
                hp50_1.SetActive(true);
                dialogue += Time.deltaTime;
                if (dialogue >= 3f)
                {
                    hp50_1.SetActive(false);
                    dialogue = 0;
                    count++;
                }
            }

            if (curHP <= maxHP * .5f && count == 4)
            {
                hp50_2.SetActive(true);
                dialogue += Time.deltaTime;
                if (dialogue >= 3f)
                {
                    hp50_2.SetActive(false);
                    dialogue = 0;
                    count++;
                }
            }

            if (curHP <= maxHP * .5f && count == 5)
            {
                hp50_3.SetActive(true);
                dialogue += Time.deltaTime;
                if (dialogue >= 3f)
                {
                    hp50_3.SetActive(false);
                    dialogue = 0;
                    count++;
                }
            }
            yield return null;
        }
    }
}
