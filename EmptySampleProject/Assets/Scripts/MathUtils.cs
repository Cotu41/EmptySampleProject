using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MathUtils
{
    public const float TAU = Mathf.PI * 2;




    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 aToB = b - a;
        Vector3 aToV = value - a;
        return Vector3.Dot(aToV, aToB) / Vector3.Dot(aToB, aToB);
    }


    public static float Remap(float iMin, float iMax, float oMin, float oMax, float value)
    {
        return Mathf.Lerp(oMin, oMax, Mathf.InverseLerp(iMin, iMax, value));
    }
}
