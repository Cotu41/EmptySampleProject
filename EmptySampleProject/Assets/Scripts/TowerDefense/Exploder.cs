using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Exploder : MonoBehaviour
{
    SphereCollider c;
    public float radius = 10f;
    public float max_force = 20f;
    List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        c = GetComponent<SphereCollider>();
        c.radius = radius;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTRY");
        Enemy enemy;
        if(other.TryGetComponent<Enemy>(out enemy))
        {
            enemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy;
        if(other.TryGetComponent<Enemy>(out enemy))
        {
            enemies.Remove(enemy);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Detonate();
        }
    }

    float GetExplosiveMagnitudeAt(Vector3 position)
    {
        float distance = (position - transform.position).magnitude;
        float force = max_force * (Mathf.Abs(distance - radius) / radius);
        return force;
    }

    public void Detonate()
    {
        foreach(Enemy e in enemies)
        {
            e.Shove(transform.position, GetExplosiveMagnitudeAt(e.transform.position));
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Enemy e in enemies)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, e.transform.position);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(e.transform.position, e.transform.position + (e.transform.position - transform.position).normalized * GetExplosiveMagnitudeAt(e.transform.position)); // show a longer line for a more violent blast (when the target is closer)
        }
    }

}
