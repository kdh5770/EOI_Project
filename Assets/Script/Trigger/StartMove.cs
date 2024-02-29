using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Gamemanager.instance.characterstatecontroller.ChangeState(CharacterSTATE.INTERACTION);
    }
}
