using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSkill_A : MonsterSkill
{
    public int loopMaxCount = 2;
    public int loopCurCount = 0;

    public List<Vector3> firstTargets;
    public Transform secondTarget;
    public float waitTime; // 두 번째 목표지점으로 던지기 전 대기 시간
    public GameObject bullet;
    public Transform Gun;
    bool hasReachedFirstTarget = false;
    public List<GameObject> bullets = new List<GameObject>();


    public override void ApplyReaction(GameObject target)
    {
       
    }

    public override void ApplySkillEffect(GameObject target)
    {
        
    }

    public override void ExecuteAttack(GameObject _target)
    {
        bullets.Clear();
        firstTargets.Clear();
        target = _target;
        waitTime = 2f;

        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsSpout2");
    }

    public override void ActionAttack()
    {
        if (loopCurCount == 0)
        {
            hasReachedFirstTarget = true;
            for (int i = 0; i < 10; i++)
            {
                bullets.Add(Instantiate(bullet, Gun.transform.position, Quaternion.identity));
            }
            MoveToFirstTarget();
            StartCoroutine(Up());
        }

        if (++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;
        }
    }

    void MoveToFirstTarget()
    {

        for (int i = 0; i < 10; i++)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            Vector3 randomPosition = transform.up * 2 + randomDirection;
            firstTargets.Add(randomPosition);
        }
        // 첫 번째 목표지점으로 이동
        for (int i = 0; i < 10; i++)
        {
            Vector3 dir = firstTargets[i].normalized;
            bullets[i].GetComponent<Rigidbody>().AddForce(dir * 5, ForceMode.Impulse);
        }
    }

    IEnumerator MoveToSecondTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    secondTarget = col.gameObject.transform;
                    break;
                }
            }
        }

        foreach (GameObject bullet in bullets)
        {
            Vector3 directionToSecondTarget = (secondTarget.position - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().AddForce(directionToSecondTarget * 30, ForceMode.Impulse);
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Up()
    {
        if (hasReachedFirstTarget)
        {
            while (waitTime >= 0)
            {
                // 대기 시간이 지난 후 두 번째 목표지점으로 던지기
                waitTime -= Time.deltaTime;
                yield return null;
            }

            if (waitTime <= 0f)
            {
                hasReachedFirstTarget = false;
                foreach (GameObject bullet in bullets)
                {
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                StartCoroutine(MoveToSecondTarget());
            }
        }
    }
}