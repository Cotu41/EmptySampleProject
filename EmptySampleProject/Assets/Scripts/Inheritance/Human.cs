using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{

    float speed = 4f;


    public override Color GetSpriteColor()
    {
        return Color.yellow;
    }

    public override void Speak()
    {
        Debug.Log("Hello, traveller!");
    }

    public override void Walk(Vector2 direction)
    {
        transform.position += (Vector3) direction.normalized * speed * Time.deltaTime;
    }
}
