using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayTrigger : MonoBehaviour
{
    [SerializeField]
    public GameObject playerhead;

    [SerializeField]
    public Bounds bounds;

    bool triggered = false;

    Vector3 entrypoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!triggered && bounds.Contains(playerhead.transform.position))
        {
            triggered = true;
            entrypoint = playerhead.transform.position;
        }

        if(triggered && !bounds.Contains(playerhead.transform.position))
        {
            Vector3 direction = (playerhead.transform.position - entrypoint).normalized;
            float dotprod = Vector3.Dot(transform.forward, direction);

            if (dotprod >= 0.8f) Debug.Log("ding!");
            triggered = false;
        }
    }

  

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
