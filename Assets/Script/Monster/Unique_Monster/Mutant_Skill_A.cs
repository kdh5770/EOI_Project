using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_A : MonsterSkill
{
    // ¶¥ Ä¥ ¶§ ¸ó½ºÅÍ ¹Ý°æ ³»¿¡ ·£´ýÀ¸·Î ÃË¼ö Æ¢¾î³ª¿Í¼­ °ø°Ý
    [SerializeField]
    private GameObject SkillPrefab;
    public float radius = 10f;
    public int numberOfSkills = 20;
    private List<GameObject> spawnedSkills = new List<GameObject>();
    private float skillDestroyDelay = 1f;
    public override void ApplyReaction(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplySkillEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteAttack(GameObject _target)
    {
        target = _target;
        animationEvent.ActionAttack += ActionAttack;
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsSkillA");

    }
    public override void ActionAttack()
    {
        animationEvent.ActionAttack -= ActionAttack;
        Vector3 monsterPosition = transform.position;
        for (int i = 0; i < numberOfSkills; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * radius;
            Vector3 randomPosition = new Vector3(monsterPosition.x + randomOffset.x, monsterPosition.y, monsterPosition.z + randomOffset.y);
            GameObject spawnedSkill = Instantiate(SkillPrefab, randomPosition, Quaternion.identity);
            spawnedSkills.Add(spawnedSkill);

            Invoke("DestroySkill", skillDestroyDelay);
        }
    }

    void DestroySkill()
    {
        foreach(var skill in spawnedSkills)
        {
            Destroy(skill);
        }
        spawnedSkills.Clear();
    }
}