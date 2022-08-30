using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardLook : MonoBehaviour
{

    public Transform player;
    Light guardlight;


    bool spotting = false;


    // Start is called before the first frame update
    void Start()
    {

        RadialTrigger.InTrigger += SpottingPlayer;

        TryGetComponent<Light>(out guardlight);
        if(guardlight == null)
        {
            Debug.LogError("Guard doesn't have a light!");
        }
    }

    private void SpottingPlayer()
    {
        spotting = true;
        guardlight.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = player.position - transform.position;
        look = look.normalized;

        
        float angle = Mathf.Atan2(look.x, look.z);
        transform.rotation = Quaternion.Euler(0, Mathf.Rad2Deg*angle, 0);

        if(spotting)
        {
            guardlight.color = Color.red;
        }
        else
        {
            guardlight.color = Color.green;
        }
    }


    //at the end of each frame, reset spotting to false. not sure if there's a better way to do this    
    private void LateUpdate()
    {
        spotting = false;
    }
}
