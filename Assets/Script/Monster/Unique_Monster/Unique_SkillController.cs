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
    }

    public void SetAttackState(GameObject _target)
    {
        if (!isSpecialSkill)
        {
            curSkill = skills[skillCount++];
            if (skillCount >= skills.Count)
            {
                skillCount = 0;
            }
            curSkill.ExecuteAttack(_target);
        }
    }
}
