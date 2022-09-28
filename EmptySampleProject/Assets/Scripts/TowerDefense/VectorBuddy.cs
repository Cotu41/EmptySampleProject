using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorBuddy
{
    public static void DrawVector(Vector3 a, Vector3 b) => Debug.DrawLine(a, b);

    public static void DrawVector(Vector2 a, Vector2 b) => Debug.DrawLine(a, b);

    public static void DrawVector(Vector3 a, Vector3 b, Color color) => Debug.DrawLine(a, b, color);

    public static void DrawVector(Vector2 a, Vector2 b, Color color) => Debug.DrawLine(a, b, color);

    public static void DrawVectorLocal(Vector3 origin, Vector3 endpoint, Color color)
    {
        Debug.DrawLine(origin, origin + endpoint, color);
    }

    public static void DrawVectorFrom(Vector3 origin, Vector3 direction, float length)
    {
        Debug.DrawLine(origin, origin + (direction.normalized * length));
    }

    public static void DrawBasisVectors(Vector3 origin)
    {
        Debug.DrawLine(origin, origin + Vector3.right, Color.red);
        Debug.DrawLine(origin, origin + Vector3.up, Color.green);
        Debug.DrawLine(origin, origin + Vector3.forward, Color.blue);
    }

    public static void DrawBasisVectors(Vector2 origin)
    {
        Debug.DrawLine(origin, origin + Vector2.right, Color.red);
        Debug.DrawLine(origin, origin + Vector2.up, Color.green);
    }


}
