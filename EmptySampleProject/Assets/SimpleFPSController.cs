using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    float roty = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

        Vector3 newfwd = new Vector3(1, 0, 1);
        newfwd.Scale(transform.forward);



        if(Input.GetKey(KeyCode.W))
        {
            move += newfwd;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            move -= newfwd;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }

        transform.position += (move.normalized * speed) * Time.deltaTime;


        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y"));

        float x_look = Input.GetAxis("Mouse X");
        float y_look = Input.GetAxis("Mouse Y");

        float rotx = transform.localEulerAngles.y + x_look;
        roty += y_look;
        roty = Mathf.Clamp(roty, -60f, 60f);

        transform.localEulerAngles = new Vector3(-roty, rotx, 0);
    }
}
