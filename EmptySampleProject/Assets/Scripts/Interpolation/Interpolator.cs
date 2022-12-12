using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolator : MonoBehaviour
{
    [SerializeField]
    public Transform thing;

    [SerializeField]
    public Transform a, b;

    [SerializeField]
    public Color colorA, colorB;


    [SerializeField]
    [Range(0, 1)]
    public float blend = 0;

    [SerializeField]
    public float sphereRadius = 1f;
    private void OnDrawGizmos()
    {
        Vector3 lerpPos = Vector3.Lerp(a.position, b.position, blend);

        Gizmos.color = Color.Lerp(colorA, colorB, blend);
        Gizmos.DrawSphere(lerpPos, sphereRadius);

        float distFromFinish = MathUtils.InverseLerp(a.position, b.position, lerpPos); // I know we could get this just from blend, but for the sake of demonstration we do it like this

        UnityEditor.Handles.Label(lerpPos + (Vector3.up * 1f), new GUIContent("Progress to B: " + (distFromFinish * 100f) + "%"));


    }

    private void Update()
    {
        blend = (Mathf.Cos(Time.time) + 1f) / 2f;
    }
}
