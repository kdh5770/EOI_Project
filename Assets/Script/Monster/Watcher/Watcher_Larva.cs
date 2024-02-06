using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher_Larva : MonsterSkill
{
    public GameObject watcher;
    public GameObject larva;

    public override void ActionAttack()
    {
        throw new System.NotImplementedException();
    }

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
        StartCoroutine(UP());
    }

    IEnumerator UP()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Larva"))
                {
                    watcher.transform.position = col.transform.position;
                    break;
                }
            }
        }
        yield return null;
    }
}
