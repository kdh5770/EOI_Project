using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharaterBaseState
{
    public bool IsChageState
    {
        get { return IsChageState; }
        protected set { IsChageState = value; }
    }
    public virtual void OnEnterState() { }
    public virtual void OnUpdateState() { }
    public virtual void OnFixedUpdateState() { }
    public virtual void OnExitState() { }

}

public class MoveState : ICharaterBaseState
{


    public void OnEnterState()
    {
        throw new System.NotImplementedException();
    }

    public void OnExitState()
    {
        throw new System.NotImplementedException();
    }

    public void OnFixedUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdateState()
    {
        throw new System.NotImplementedException();
    }
}
