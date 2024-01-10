using Unity.VisualScripting;
using UnityEngine;

public class PrefabLauncher : MonoBehaviour
{
    public GameObject prefab; // Assign your prefab in the inspector

    void Update()
    {
        // Check for a mouse click
        if (Input.GetMouseButtonDown(0))
        {
            LaunchPrefabAtMousePosition();
        }
    }

    void LaunchPrefabAtMousePosition()
    {
        // Convert mouse position to world position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Distance from the camera
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Instantiate the prefab at the mouse position
        GameObject obj = Instantiate(prefab, worldPos, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 10, ForceMode.Impulse);
    }
}