

using UnityEngine;

public interface IItem
{
    public void UsingItem(GameObject _target);
}

public class HealthItem : IItem
{
    public GameObject target;
    public void UsingItem(GameObject _target)
    {
        target = _target;
        target.GetComponent<CharacterHealth>().TakePotion();
    }
}

public class GoodsItem : IItem
{
    public GameObject target;
    public void UsingItem(GameObject _target)
    {
        target = _target;
        target.GetComponent<CharacterHealth>().TakeGoods();
    }
}