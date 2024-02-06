using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterSkill : Attack, ISkillEffect
{
    public abstract void ApplyReaction(GameObject target);

    public abstract void ApplySkillEffect(GameObject target);
}
