using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();

        if(Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }

        if(Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        movement = movement.normalized;
        transform.position += movement * Time.deltaTime;



    }
}
