using UnityEngine;

public interface IReactionEffect
{
    void ApplyReaction(GameObject target);
}

public class KnockbackEffect : IReactionEffect
{
    public float pushForce = 2f;
    public void ApplyReaction(GameObject target)
    {
        target.GetComponent<Rigidbody>().AddForce((target.transform.forward * -1) * pushForce, ForceMode.Impulse);
    }
}

public class StiffenEffect : IReactionEffect
{
    public void ApplyReaction(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}

public interface ISkillEffect : IReactionEffect
{
    void ApplySkillEffect(GameObject target);
}
