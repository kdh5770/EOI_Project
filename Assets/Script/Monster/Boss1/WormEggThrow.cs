using UnityEngine;


public class WormEggThrow : Attack, ISkillEffect
{


    public void ApplyReaction(GameObject target)
    {

    }

    public void ApplySkillEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteAttack(GameObject _target)
    {
        //Vector3 direction = (target.transform.position - firePos.position).normalized;
        //GameObject preObj = Instantiate(bullet, firePos.position, Quaternion.identity);
        //preObj.GetComponent<Rigidbody>().AddForce(direction * encounter, ForceMode.Impulse);
    }
}
