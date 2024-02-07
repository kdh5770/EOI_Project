using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Watcher_Larva : MonsterSkill
{
    [Header("¹øµ¥±â")]
    public GameObject larva;

    NavMeshAgent Nav;
    Rigidbody RB;


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
        Nav = GetComponent<NavMeshAgent>();
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("isLarva");
        Nav.enabled = false;
    }

    public override void ActionAttack()
    {
        StartCoroutine(UP());
    }

    IEnumerator UP()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("LarvaTf"))
                {
                    larva = col.gameObject;
                    break;
                }
            }
        }

        if (larva != null)
        {
            gameObject.transform.position = larva.transform.position;
        }
        else
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {

        }
    }
}
