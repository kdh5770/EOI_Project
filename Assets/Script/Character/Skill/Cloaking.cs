using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloaking : SkillTable
{
    // Start is called before the first frame update
    void Start()
    {
        Initsetting();
    }

    public override void Initsetting()
    {
        S_Data.CurOxygen = 100f;
        S_Data.MaxOxygen = 100f;
        S_Data.SkillName = "IsCloaking";
    }

    public override void Using()
    {
        base.Using();
    }

}
