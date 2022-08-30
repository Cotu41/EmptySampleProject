using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    
    [HideInInspector]
    public static List<GameObject> spawnedEnemies;

    public bool spawning = true;

    public float spawn_cooldown = 5f;

    [Header("Difficulty Ramping")]
    [Tooltip("Whether or not the difficulty ramps should be used. Otherwise, use spawn_cooldown")]
    public bool useDifficultyRamps = false;
    [Tooltip("Specifies how the spawn cooldown changes over time, thus making the game gradually harder for the player. Having the graph repeat can make waves.")]
    public AnimationCurve spawnCooldownRamp;
    [Tooltip("The chance over time (between 0 and 1) that an extra enemy will spawn when an enemy spawns")]
    public AnimationCurve spawnHordeChance; // I don't really like this but this little "game" doesn't have much to it right now, you just wait until it gets impossible
    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        StartCoroutine(SpawnRoutine());
        Enemy.OnDeath += Enemy_OnDeath;
    }

    private void Enemy_OnDeath(Enemy e, params string[] info)
    {
        spawnedEnemies.Remove(e.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            

            if (spawning)
                SpawnEnemy();
            if (useDifficultyRamps)
            {
                spawn_cooldown = spawnCooldownRamp.Evaluate(Time.timeSinceLevelLoad);
                float extraSpawnRoll = spawnHordeChance.Evaluate(Time.timeSinceLevelLoad);
                if (Random.Range(0, 1) <= extraSpawnRoll && spawning)
                {
                    yield return new WaitForSeconds(0.3f);
                    spawn_cooldown -= 0.3f;
                    SpawnEnemy();
                }
            }

                yield return new WaitForSeconds(spawn_cooldown);
            
            
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
        enemy = GameObject.Instantiate(enemy, transform);
        spawnedEnemies.Add(enemy);
    }
}
