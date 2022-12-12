using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Character
{

    float speed = 2f; // slower than humans


    public override Color GetSpriteColor()
    {
        return Color.green;
    }

    public override void Speak()
    {
        Debug.Log("Urrk!");
    }

    public override void Walk(Vector2 direction)
    {
        transform.position += (Vector3) direction.normalized * speed * Time.deltaTime;
    }
}
