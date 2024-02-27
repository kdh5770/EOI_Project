using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Image Options;
    public Image Load;

    private void Start()
    {
        Options.enabled = false;
        Load.enabled = false;
    }
    private void Update()
    {
        if ((Options.enabled || Load.enabled) && Input.GetKey(KeyCode.Escape))
        {
            Options.enabled = false;
            Load.enabled = false;
        }
    }


    public void OnClick_Start() // 게임 시작
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_Exit() // 게임 종료
    {
        Application.Quit();
    }

    public void OnClick_Option_True() // 옵션창 활성화
    {
        Options.enabled = true;
        Load.enabled = false;
    }

    public void OnClick_Load_True() // 로드창 활성화
    {
        Load.enabled = true;
        Options.enabled = false;
    }
}
