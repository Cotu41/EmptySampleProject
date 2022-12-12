using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCharacter : MonoBehaviour
{
    Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        GetComponent<SpriteRenderer>().color = character.GetSpriteColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        character.Speak(); // do the unique behavior
    }

}
