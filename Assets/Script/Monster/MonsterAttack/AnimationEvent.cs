using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject AttackOBJ;
    public void Test()
    {
        bool ish = AttackOBJ.activeSelf;
        AttackOBJ.SetActive(!ish);
    }
}
