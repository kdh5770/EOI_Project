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
    private const float offest = 1.5f;
    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;
        

        Vector3 direction = ((target.transform.position + target.transform.up * offest) - transform.root.position).normalized;
        transform.LookAt(target.transform.position);
        BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.LookRotation(direction));

        //BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f;
        //BulletEft.transform.LookAt(target.transform.position + target.transform.up * offest);
      

        animator.SetTrigger("isThrow");
    }

    public override void ActionAttack()
    {
        BulletEft.GetComponent<Rigidbody>().AddForce(BulletEft.transform.forward * 15f, ForceMode.Impulse);
        Destroy(BulletEft, 5f);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
