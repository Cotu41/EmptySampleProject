using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Character
{

    float speed = 3f;


    public override Color GetSpriteColor()
    {
        return Color.red;
    }

    public override void Speak()
    {
        Debug.Log("'Ello there! Urist Inheritsmethods, pleased to meet 'ya!");
    }

    public override void Walk(Vector2 direction)
    {
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }
}
