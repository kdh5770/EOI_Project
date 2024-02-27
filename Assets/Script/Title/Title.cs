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


    public void OnClick_Start() // ���� ����
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_Exit() // ���� ����
    {
        Application.Quit();
    }

    public void OnClick_Option_True() // �ɼ�â Ȱ��ȭ
    {
        Options.enabled = true;
        Load.enabled = false;
    }

    public void OnClick_Load_True() // �ε�â Ȱ��ȭ
    {
        Load.enabled = true;
        Options.enabled = false;
    }
}
