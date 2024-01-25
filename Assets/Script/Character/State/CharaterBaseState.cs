using UnityEngine;

public abstract class CharaterBaseState
{
    public CharacterStateController controller;

    public void InitState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }

    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnFixedUpdateState();
    public abstract void OnExitState();

}

