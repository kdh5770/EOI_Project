using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : MonoBehaviour
{
    public enum STATE
    {
        NONE = 0,
        Idle,
        Moving,
        UsingMelee,
        UsingGun,
        Reaction,
        CutScene,
        Dead
    }
}
