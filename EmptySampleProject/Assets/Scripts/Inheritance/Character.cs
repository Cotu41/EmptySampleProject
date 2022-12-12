using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public abstract class Character : MonoBehaviour
{
    public abstract void Speak();
    public abstract void Walk(Vector2 direction);
    public abstract Color GetSpriteColor();

}

public abstract class Item : MonoBehaviour
{
    public abstract void Use();
    public abstract string Inspect();
}
