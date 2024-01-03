using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuildTest : MonoBehaviour
{
    public PlayerInput playerInput;

    public GameObject panel;
    public GameObject checkPre;
    public GameObject preObj;

    public bool isPop;

    public string inputText;

    public TextMeshPro textMeshPro;
    int debugCount;

    private void Start()
    {
        inputText = null;
        isPop = true;
        debugCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPop)
            {
                inputText += "Position: " + transform.position.ToString() + "\n";
                isPop = false;
                playerInput.enabled = isPop;

                Vector3 cuvePos = new Vector3(transform.position.x, 20, transform.position.z);
                preObj = Instantiate(checkPre, cuvePos, Quaternion.identity);
                preObj.GetComponent<DebugTestCube>().text.text = debugCount++.ToString();
                panel.SetActive(!panel.activeSelf);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }

    public void OnUpdateString(string _str)
    {
        inputText += _str + "\n\n";

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        isPop = true;
        playerInput.enabled = isPop;

        Debug.Log(inputText);
    }
}
