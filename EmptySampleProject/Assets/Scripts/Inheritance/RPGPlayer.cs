using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RPGPlayer : MonoBehaviour
{

    Character playerCharacter;
    SpriteRenderer body;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GetComponent<Character>();
        body = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerCharacter.Walk(Vector2.up);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            playerCharacter.Walk(Vector2.down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerCharacter.Walk(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerCharacter.Walk(Vector2.right);
        }


        body.color = playerCharacter.GetSpriteColor();
    }
}
