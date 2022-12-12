using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPlotter : MonoBehaviour
{
  


    private void Start()
    {
        
    }



    [SerializeField]
    [Min(3)]
    public int numDots = 3;

    [SerializeField]
    public float distance = 1;

    [SerializeField]
    public float dotSize = 1f;

    private void OnDrawGizmos()
    {
        float TAU = Mathf.PI * 2;
        for(int i = 1; i <= numDots; i++)
        {
            float x = distance * Mathf.Cos(((float)i / numDots) * TAU);
            float y = distance * Mathf.Sin(((float)i / numDots) * TAU);
            DrawCircle(new Vector3(x, y, 0));

        }
    }

    void DrawCircle(Vector3 here)
    {
        UnityEditor.Handles.DrawSolidDisc(here, Vector3.forward, dotSize);

    }

}
