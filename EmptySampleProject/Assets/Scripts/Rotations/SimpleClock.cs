using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClock : MonoBehaviour
{
    [SerializeField]
    public float size = 10f;


    private void OnDrawGizmos()
    {
        System.DateTime now = System.DateTime.Now;

        // draw clock face
        UnityEditor.Handles.DrawWireArc(transform.position, Vector3.forward, Vector3.up * size, 360, size * 1.10f); // give a 10% margin
        // draw hands
        DrawTime(now);
    }

    void DrawTime(System.DateTime now)
    {
        float TAU = Mathf.PI * 2f;

        // hour hand
        float nowhours = now.Hour % 12;
        float hour_angle = (nowhours / 12f) * TAU * -1; // -1 because we go clockwise
        hour_angle += (0.25f*TAU); // apply this offset to all angles since the "start" of the circle is really at 1/4 TAU
        float h_x = Mathf.Cos(hour_angle);
        float h_y = Mathf.Sin(hour_angle);
        UnityEditor.Handles.DrawLine(transform.position, new Vector3(h_x, h_y, 0) * size);
        UnityEditor.Handles.Label(new Vector3(h_x, h_y, 0) * size, new GUIContent("H: " + nowhours));

        //minute hand
        float nowminutes = now.Minute % 60f;
        float minute_angle = (nowminutes / 60f) * TAU * -1;
        minute_angle += (0.25f * TAU);
        float m_x = Mathf.Cos(minute_angle);
        float m_y = Mathf.Sin(minute_angle);
        UnityEditor.Handles.DrawLine(transform.position, new Vector3(m_x, m_y, 0) * size);
        UnityEditor.Handles.Label(new Vector3(m_x, m_y, 0) * size, new GUIContent("M: " + nowminutes));

        //second hand

        Color tempcolor = UnityEditor.Handles.color;
        UnityEditor.Handles.color = Color.red;

        float nowseconds = now.Second % 60f;
        nowseconds = (float)((int)nowseconds); //truncate for more realistic "clicking" second hand
        float second_angle = (nowseconds/ 60f) * TAU * -1;
        second_angle += (0.25f * TAU);
        float s_x= Mathf.Cos(second_angle);
        float s_y = Mathf.Sin(second_angle);
        UnityEditor.Handles.DrawLine(transform.position, new Vector3(s_x, s_y, 0) * size);
        UnityEditor.Handles.Label(new Vector3(s_x, s_y, 0) * size, new GUIContent("S: " + nowseconds));

        UnityEditor.Handles.color = tempcolor; // set color back to whatever it was before

    }
}
