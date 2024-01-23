using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger : MonoBehaviour
{

    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;
    public void InputPlayerTrigger()
    {
        if(interactions.Count > 0)
        {
            foreach(Interaction interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }
}
