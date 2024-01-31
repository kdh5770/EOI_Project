using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public TempScript tempScript;
    public SpawnTest spawnTest;
    public ItemDropManagere itemDropManagere;
    public CharacterUI characterUI;
    public TimeLineManager timeLineManager;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
       // spawnTest.SpawnMonster();
    }

}
