using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    [Tooltip("The radius of the trigger")]
    public float radius = 10f;

    [Tooltip("Any Transforms which will trigger this")]
    public Transform[] ObjectsWhichTrigger;

    public delegate void TriggerEvent();
    public static event TriggerEvent InTrigger;


    public bool inside = false;

    private void Start()
    {
        
    }

    private void Update()
    {
       

        foreach (Transform t in ObjectsWhichTrigger)
        {
            float distanceToTarget = (transform.position - t.position).magnitude;
            distanceToTarget = Mathf.Abs(distanceToTarget);

            if (distanceToTarget <= radius)
            {
                inside = true;
                InTrigger?.Invoke();
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (!inside)
            Gizmos.color = Color.green;
        else Gizmos.color = Color.red;

        foreach(Transform t in ObjectsWhichTrigger)
        {
            Gizmos.DrawLine(transform.position, t.position);
        }

        

        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
}
