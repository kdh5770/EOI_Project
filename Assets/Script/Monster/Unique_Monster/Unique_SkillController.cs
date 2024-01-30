using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unique_SkillController : MonoBehaviour
{
    public MonsterFSM bossFSM;

    public Attack curSkill;
    public List<Attack> skills;

    public int skillCount;
    public bool isSpecialSkill;

    private void Start()
    {
        bossFSM = GetComponentInParent<MonsterFSM>();
        skillCount = 0;
        curSkill = skills[0];
    }

    public void SetAttackState(GameObject _target)
    {
        if (!isSpecialSkill)
        {
            Debug.Log(curSkill);
            Debug.Log(skillCount);

            curSkill.ExecuteAttack(_target);

            if (++skillCount >= skills.Count)
            {
                skillCount = 0;
            }
            else
                curSkill = skills[skillCount];
        }
    }
}
