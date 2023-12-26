using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public CameraManager cameraManager;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
