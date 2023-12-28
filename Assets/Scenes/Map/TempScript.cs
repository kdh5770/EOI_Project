using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    #region 프레임 확인 GUI 관련 로직
    [Range(10, 150)]
    public int fontSize = 30;
    public Color color = new Color(.0f, .0f, .0f, 1.0f);
    public float width, height;
    #endregion

    void Start()
    {
        Application.targetFrameRate = 50; // 프레임 고정
        #region 마우스 커서 감추기 && 고정
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        #endregion
    }
    void Update()
    {
        
    }
    void OnGUI()
    {
        #region 프레임 확인 GUI 관련 로직
        Rect position = new Rect(width, height, Screen.width, Screen.height);

        float fps = 1.0f / Time.deltaTime;
        float ms = Time.deltaTime * 1000.0f;
        string text = string.Format("{0:N1} FPS ({1:N1}ms)", fps, ms);

        GUIStyle style = new GUIStyle();

        style.fontSize = fontSize;
        style.normal.textColor = color;

        GUI.Label(position, text, style);
        #endregion
    }
}
