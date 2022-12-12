using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVArc : MonoBehaviour
{

    [SerializeField]
    public float arcDistance = 10f;

    [SerializeField]
    [Range(0, 1f)]
    public float opacity = 0.5f;

    [SerializeField]
    [Range(10, 180)]
    public float fov = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        float TAU = Mathf.PI * 2;





        float angle = (fov / 2f);

        float y = Mathf.Sin(angle);
        float x = Mathf.Cos(angle);


        UnityEditor.Handles.DrawWireArc(transform.position, transform.up, transform.forward, angle, arcDistance);
        UnityEditor.Handles.DrawWireArc(transform.position, transform.up, transform.forward, -1 * angle, arcDistance);
        Color tempcolor = UnityEditor.Handles.color;
        UnityEditor.Handles.color = Color.blue * new Color(1, 1, 1, opacity);
        UnityEditor.Handles.DrawSolidArc(transform.position, transform.up, transform.forward, angle, arcDistance);
        UnityEditor.Handles.DrawSolidArc(transform.position, transform.up, transform.forward, -1*angle, arcDistance);

    }


}
