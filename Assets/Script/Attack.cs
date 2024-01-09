using UnityEngine;

public enum REACT_TYPE
{
    None,
    Knuckback,
    Stiffen,
    Skill
}
public abstract class Attack : MonoBehaviour
{
    public Animator animator;
    public REACT_TYPE react_type;
    public IReactionEffect reaction;
    public void Initialized()
    {
        animator = GetComponentInChildren<Animator>();

        switch (react_type)
        {
            case REACT_TYPE.None:
                break;

            case REACT_TYPE.Knuckback:
                KnockbackEffect knockbackEffect = new KnockbackEffect();
                reaction = knockbackEffect;
                break;

            case REACT_TYPE.Stiffen:
                StiffenEffect stiffenEffect = new StiffenEffect();
                reaction = stiffenEffect;
                break;

            case REACT_TYPE.Skill:
                break;
        }
    }

    private void Awake()
    {
        Initialized();
    }

    public abstract void ExecuteAttack(GameObject _target);

}
