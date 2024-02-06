using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherThrow : Attack
{
    [Header("발사체 프리팹")]
    public GameObject BulletEftPre;
    [Header("발사 위치")]
    public Transform BulletTf;
    [Header("생성된 발사체")]
    public GameObject BulletEft;

    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;
        transform.LookAt(target.transform.position);

        BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.identity);
        Vector3 direction = (target.transform.position - BulletEft.transform.position).normalized;
        BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f;
        Destroy(BulletEft, 5f);

        animator.SetTrigger("IsMelee");
    }

    public override void ActionAttack()
    {
        target.GetComponent<CharacterHealth>().TakeDamage(damage);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
