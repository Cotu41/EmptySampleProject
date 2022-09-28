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
    bool dazed = false;

    public delegate void EnemyEvent(Enemy e, params string [] info);
    public static event EnemyEvent OnDeath;

    SpriteRenderer sprite;

    Vector3 net_v = new Vector3(); // our net velocity, right now
    Vector3 frame_a = new Vector3(); // the acceleration we undergo this frame.
    float friction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        if(alive)
            UpdateMovement();
    }

    void UpdateMovement()
    {
        net_v += frame_a; // instantaneous acceleration
        net_v -= net_v.normalized * friction; // friction opposite of our direction of motion
        if(dazed && net_v.magnitude < 0.5f)
        {
            net_v = Vector3.zero;
            dazed = false;
        }
        else if(!dazed) // if we came to a stop, wait a frame before we get going again.
        {

            if (net_v.magnitude < movespeed) net_v += (Vector3.right * recovery);
            else if (net_v.magnitude > movespeed) net_v = (Vector3.right * movespeed);
        }

        transform.position += net_v * Time.deltaTime;
        frame_a = Vector3.zero;
    }

    public void Shove(Vector3 from_point, float force)
    {
        Debug.Log("SHOVE");
        frame_a = (transform.position - from_point).normalized * force;
        dazed = true;
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
            Shove(shooter.transform.position, 2f);
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
