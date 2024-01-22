using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManagere : MonoBehaviour
{
    public List<GameObject> itemsPre;
    public int dropCount;
    public int maxDropCount;

    public void SpawnItems(Vector3 position)
    {
        dropCount = Random.Range(0, maxDropCount);

        for(int i = 0; i < dropCount; i++)
        {
            int itemIndex = Random.Range(0, itemsPre.Count);
            Instantiate(itemsPre[itemIndex], GetRandeomPosition(position), Quaternion.identity);
        }
    }

    Vector3 GetRandeomPosition(Vector3 _position)
    {
        Vector2 randomPos = Random.insideUnitCircle;

        return new Vector3(randomPos.x, _position.y, randomPos.y);
    }
}
