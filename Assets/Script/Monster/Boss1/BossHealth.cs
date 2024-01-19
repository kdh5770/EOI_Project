using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonsterStatus
{
    public Slider HP;
    public int count = 0;

    private void Update()
    {
        float healthPercentage = (curHP / maxHP) * 100.0f;
        HP.value = healthPercentage;

        if (curHP <= maxHP * 0.3f && count == 0)
        {
            GetComponent<BossEnergy>().Energy();
            count++;
        }
    }
}