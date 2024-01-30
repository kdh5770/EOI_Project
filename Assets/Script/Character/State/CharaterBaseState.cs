using UnityEngine;

public abstract class CharaterBaseState
{
    protected CharacterStateController controller;

    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnFixedUpdateState();
    public abstract void OnExitState();

}

