using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillController : MonoBehaviour
{
    public MonsterFSM bossFSM;

    public Attack curSkill;
    public List<Attack> skills;
    public Attack specialSkill_A;
    public int skillCount;

    public bool isSpecialSkill;

    private void Start()
    {
        bossFSM = GetComponentInParent<MonsterFSM>();
        skillCount = 0;
        isSpecialSkill = false;
    }

    public void SetAttackState(GameObject _target)
    {
        if (!isSpecialSkill)
        {
            curSkill = skills[skillCount++];
            curSkill.ExecuteAttack(_target);
        }
        else
        {
            curSkill = specialSkill_A;
            curSkill.ExecuteAttack(_target);
        }
    }
}
