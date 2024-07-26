using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject player;
    //public TempScript tempScript;
    public SpawnManager spawnManager;
    public ItemDropManagere itemDropManagere;
    public CharacterUI characterUI;
    public PoolManager poolManager;
    public TimeLineManager timeLineManager;
    public DatabaseManager databaseManager;
    public CutSceneInteraction cutsceneinteraction;
    public CharacterStateController characterstatecontroller;
    public BGM_Manager bgm_manager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

    }
}
