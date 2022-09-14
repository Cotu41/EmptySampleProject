using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class LookDescriptionToggler : MonoBehaviour
{

    [SerializeField]
    public GameObject playerHead;

    [SerializeField]
    public GameObject toggles;

    [SerializeField]
    public float triggerDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = (this.transform.position - playerHead.transform.position);
        if (distance.magnitude > triggerDistance)
        {
            toggles.SetActive(false);
            return;
        }

            distance = distance.normalized;

        float dotProd = Vector3.Dot(distance, playerHead.transform.forward);

        if (dotProd >= 0.99f)
        {
            toggles.SetActive(true);
        }
        else toggles.SetActive(false);
    }




}
