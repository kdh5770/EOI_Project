using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonsterStatus
{
    public Slider HP;

    private void Update()
    {
        float healthPercentage = (curHP / maxHP) * 100.0f;
        HP.value = healthPercentage;
    }
}