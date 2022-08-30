using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float cost = 10f;
    public float p_velocity = 10f;
    public float p_damage = 3f;
    
    [Tooltip("The number of shots this turret can fire within one minute if firing continuously")]
    public int fire_rate = 300;

    public float range = 5f;

    bool shooting = false;
    Enemy target = null;


    float shotCooldown;
    float lastShotAt = 0; //timestamp of last shot


    // Start is called before the first frame update
    void Start()
    {
        shotCooldown = 60f / (float)fire_rate; // in seconds. Need to convert to float otherwise we truncate and will typically have an infinite fire rate
    }

    // Update is called once per frame
    void Update()
    {
        if (!shooting)
        {
            CheckForEnemies();
        }
        else if (Mathf.Abs((target.transform.position - transform.position).magnitude) > range || !target.alive)
        {
            shooting = false;
            target = null;
        }
        else if(Time.time >= lastShotAt + shotCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        lastShotAt = Time.time;
        target?.HitBy(this);
    }

    void CheckForEnemies()
    {
        foreach(GameObject enemy in EnemySpawner.spawnedEnemies)
        {
            if(Mathf.Abs((enemy.transform.position - transform.position).magnitude) <= range)
            {
                Enemy t;
                if(enemy.TryGetComponent<Enemy>(out t))
                {
                    shooting = true;
                    target = t;
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (shooting)
        {
            Gizmos.color = Color.red;
        }
        else Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
