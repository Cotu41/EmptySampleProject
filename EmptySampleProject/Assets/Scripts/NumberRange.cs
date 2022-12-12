using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRange : MonoBehaviour
{
    [SerializeField]
    public float max, startingValue, min;

    float value;


    public delegate void NumberRangeEvent(float oldValue, float newValue);
    public event NumberRangeEvent OnHitMax, OnHitMin, OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        value = startingValue;
        if (value > max) value = max;
        if (value < min) value = min;
    }


    public void SetValue(float value)
    {
        float tempValue = value;
        if(tempValue >= max)
        {
            tempValue = max;
            OnHitMax?.Invoke(this.value, tempValue);
        }
        else if(tempValue <=  min)
        {
            tempValue = min;
            OnHitMin?.Invoke(this.value, tempValue);
        }


        if(tempValue != this.value)
        {
            OnValueChanged?.Invoke(this.value, tempValue);
            this.value = tempValue;
        }
    }

    public float GetValue()
    {
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
