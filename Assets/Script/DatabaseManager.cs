using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] string monsterDB_FileName;
    [SerializeField] string dialogDB_FileName;

    public Dictionary<int, MonsterData> monsterDataDic = new Dictionary<int, MonsterData>();

    private void Start()
    {
        ParseMonsterData();

        foreach(MonsterData data in monsterDataDic.Values )
        {
            Debug.Log(data.ATK);
        }
    }

    void ParseMonsterData()
    {
        TextAsset csvData = Resources.Load<TextAsset>(monsterDB_FileName);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for(int i = 1; i < data.Length; i++)
        {
            string[] row_data = data[i].Split(new char[] { ',' });
            try
            {
                int id = int.Parse(row_data[0]);
                string name = row_data[1];
                float hP = float.Parse(row_data[2]);
                float ATK = float.Parse(row_data[3]);
                float DEF = float.Parse(row_data[4]);
                float speed = float.Parse(row_data[5]);
                float sightRange = float.Parse(row_data[6]);
                float dropItemCount = float.Parse(row_data[7]);
                Vector3 scale = new Vector3(
                    float.Parse(row_data[8]),
                    float.Parse(row_data[9]),
                    float.Parse(row_data[10])
                );

                MonsterData monsterData = new MonsterData(hP, ATK, DEF, speed, sightRange, dropItemCount, scale);
                monsterDataDic.Add(id, monsterData);
            }
            catch (System.FormatException e)
            {
                Debug.LogError($"Error parsing row {i}: {e.Message}");
            }
        }
    }
}
