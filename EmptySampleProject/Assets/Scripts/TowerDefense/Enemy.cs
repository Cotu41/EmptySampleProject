using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float movespeed = 6f;
    float currentSpeed = 0f;

    public float recovery = 3f;
    public float loot = 1f;

    public bool alive = true;


    public delegate void EnemyEvent(Enemy e, params string [] info);
    public static event EnemyEvent OnDeath;

    SpriteRenderer sprite;

    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {


        if(alive)
        {
            //move toward player base

            //right now I'm just gonna have them move in a straight line because I'm lazy

            transform.position += (Vector3.right * currentSpeed) * Time.deltaTime;

            // accelerate the enemy up to their movespeed, so hits can stagger them if applicable
            // adds more depth to enemy types. Some fast enemies may move really quickly but only once they get up to speed, and are thus more powerful in groups but easily handled
            // on their own. Other enemies may move more slowly, but aren't staggered at all and need consistent firepower to bring them down.
            if (currentSpeed < movespeed) currentSpeed += recovery * Time.deltaTime;
            else if (currentSpeed > movespeed) currentSpeed = movespeed;
        }   
    }

    public void HitBy(Tower shooter)
    {

        health -= shooter.p_damage;
        currentSpeed = 0f;
        if (health <= 0)
        {
            alive = false;
            OnDeath?.Invoke(this, "killer:" + shooter.GetInstanceID()); // 99% chance it'll never be used since this is just a prototype for digital prototypes, but support for a killfeed lol
            StopAllCoroutines();
            StartCoroutine(DeathCoroutine());
        }
        else
        {
            if(visualdamage != null)
            {
                StopCoroutine(visualdamage);
            }
            visualdamage = StartCoroutine(VisuallyDamage());
        }
    }

    IEnumerator DeathCoroutine()
    {
        float fadeRemaining = deathFadeDuration;
        Color current = sprite.color;
        while(fadeRemaining > 0)
        {
            float lerpvalue = 1f - (fadeRemaining / deathFadeDuration);
            sprite.color = Color.Lerp(current, Color.clear, 1 - (fadeRemaining / deathFadeDuration));
            sprite.transform.localScale = new Vector3(1+lerpvalue, 1+lerpvalue);
            
            
            fadeRemaining -= Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(5f);
        Destroy(this.transform.gameObject);
    }

    [Header("Visual Settings")]
    [Tooltip("The time it takes to fade from the damage color to the normal color")]
    public float hitFadeDuration = 1f;

    public Color normal = Color.white;
    public Color damage = Color.red;

    [Tooltip("The time it takes for an enemy to fade away on death")]
    public float deathFadeDuration = 2f;
    public float deathSpriteSizeMultiplier = 2f;

    Coroutine visualdamage = null;
    IEnumerator VisuallyDamage()
    {
        sprite.color = damage;
        float fadeRemaining = hitFadeDuration;
        yield return null;
        while(fadeRemaining > 0)
        {
            sprite.color = Color.Lerp(damage, normal, 1 - (fadeRemaining / hitFadeDuration));
            fadeRemaining -= Time.deltaTime;
            yield return null;
        }
        visualdamage = null;
    }
}
