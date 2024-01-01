using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    public enum ShapeType
    {
        Line,
        Sphere
    }

    public enum RainbowColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public ShapeType shapeType;
    public RainbowColor gizmoColor;

    // Variables for drawing
    public Vector3 lineStart = Vector3.zero;
    public Vector3 lineEnd = Vector3.right;
    public float sphereRadius = 0.5f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = GetColorFromEnum(gizmoColor);

        switch (shapeType)
        {
            case ShapeType.Line:
                DrawLineGizmo();
                break;
            case ShapeType.Sphere:
                DrawSphereGizmo();
                break;
        }
    }

    void DrawLineGizmo()
    {
        Gizmos.DrawLine(transform.position + lineStart, transform.position + lineEnd);
    }

    void DrawSphereGizmo()
    {
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    Color GetColorFromEnum(RainbowColor color)
    {
        switch (color)
        {
            case RainbowColor.Red:
                return Color.red;
            case RainbowColor.Orange:
                return new Color(1, 0.5f, 0);
            case RainbowColor.Yellow:
                return Color.yellow;
            case RainbowColor.Green:
                return Color.green;
            case RainbowColor.Blue:
                return Color.blue;
            case RainbowColor.Indigo:
                return new Color(0.294f, 0, 0.51f);
            case RainbowColor.Violet:
                return new Color(0.58f, 0, 0.827f);
            default:
                return Color.white;
        }
    }
}
