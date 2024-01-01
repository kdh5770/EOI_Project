using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public CameraManager cameraManager;
    public TempScript tempScript;
    public SpawnManager spawnManager;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

    }
 
}
