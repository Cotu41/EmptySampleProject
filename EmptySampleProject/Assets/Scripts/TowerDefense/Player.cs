using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float money = 20f;
    public int kills = 0;
    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnDeath += Enemy_OnDeath;
    }

    private void Enemy_OnDeath(Enemy e, params string [] info)
    {
        kills++;
        money += e.loot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
