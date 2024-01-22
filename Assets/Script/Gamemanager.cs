using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public CameraManager cameraManager;
    public TempScript tempScript;
    public SpawnTest spawnTest;
    public ItemDropManagere itemDropManagere;
    public CharacterUI characterUI;

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
