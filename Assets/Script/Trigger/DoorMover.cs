using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorMover : Interaction
{
    public float speed = 1f;
    public float moveTime = 5f;

    public List<GameObject> doorObj;
    private Vector3[] directions = new Vector3[4];

    private void Start()
    {
        directions[0] = new Vector3(-1, 1, 0);  // Northwest
        directions[1] = new Vector3(1, 1, 0);   // Northeast
        directions[2] = new Vector3(-1, -1, 0); // Southwest
        directions[3] = new Vector3(1, -1, 0);  // Southeast
    }
    public override void Interact()
    {
        StartCoroutine(MoveDoor());
    }


    IEnumerator MoveDoor()
    {
        float elapsedTime = 0;

        while (elapsedTime < moveTime)
        {
            for (int i = 0; i < doorObj.Count; i++)
            {
                doorObj[i].transform.Translate(directions[i] * speed * Time.deltaTime);

            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
