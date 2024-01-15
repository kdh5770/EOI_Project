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
    public GameObject player;

    public bool isPop;

    public string inputText;

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
                Time.timeScale = 0f;
                inputText += "Position: " + transform.position.ToString() + "\n";
                isPop = false;
                playerInput.enabled = isPop;

                Vector3 cubePos = new Vector3(player.transform.position.x, 20, player.transform.position.z);
                preObj = Instantiate(checkPre, cubePos, Quaternion.identity);
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
