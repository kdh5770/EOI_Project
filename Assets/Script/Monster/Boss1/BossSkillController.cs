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

    public GameObject bulletAudio;
    public float count = 0;

    private void Start()
    {
        bossFSM = GetComponentInParent<MonsterFSM>();
        transform.root.GetComponent<WormHealth>().LowHealthEvent += SetSpecialSkill;
        skillCount = 0;
    }

    private void Update()
    {
        if (count >= 5)
        {
            bulletAudio.SetActive(false);
            count = 0;
        }

        if (bulletAudio.activeSelf)
        {
            count += Time.deltaTime;
        }
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
        else
        {
            isSpecialSkill = false;
            curSkill = specialSkill_A;
            curSkill.ExecuteAttack(_target);
        }
    }

    void SetSpecialSkill()
    {
        isSpecialSkill = true;
        transform.root.GetComponent<WormHealth>().LowHealthEvent -= SetSpecialSkill;
    }
}
