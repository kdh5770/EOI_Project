using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField; // Assign this in the inspector
    public BuildTest buildTest;

    public Camera subCamera; // Assign your sub-camera here
    public RenderTexture renderTexture; // Assign your RenderTexture here
    public string screenshotName = "BugPosition.png";




    public void OnclickSave()
    {
        buildTest.OnUpdateString(inputField.text);

        inputField.text = null;
        
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OutputDebug()
    {
        RenderTexture prevActiveRT = RenderTexture.active;

        // Set the specified RenderTexture as the active one
        RenderTexture.active = renderTexture;

        // Create a new Texture2D with the same size as the render texture
        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        // Reset the active RenderTexture
        RenderTexture.active = prevActiveRT;

        // Encode the Texture2D to a PNG and then destroy the Texture2D
        byte[] bytes = screenshot.EncodeToPNG();
        Destroy(screenshot);

        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        // Save the PNG
        string filePath = Path.Combine(desktopPath, screenshotName);
        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Screenshot saved to: {filePath}");

        // Save the inputText as a text file
        string textFilePath = Path.Combine(desktopPath, Path.GetFileNameWithoutExtension(screenshotName) + "_Text.txt");
        File.WriteAllText(textFilePath, buildTest.inputText);
        Debug.Log($"Text file saved to: {textFilePath}");

        buildTest.preObj.SetActive(true);
        Application.Quit();
    }
}
