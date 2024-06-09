using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public float startDelay;
    public float interval;
    public int enemiesSpawned;
    public int maxEnemies;

    public GameObject enemyPrefab;
    public GameObject explosion;
    public AudioSource audioPoof;

    public GameObject heartPrefab;
    public Transform player;
    public PlayerController playerController;
  

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay,interval);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        enemiesSpawned++;

        GameObject enemy = Instantiate(enemyPrefab,transform.position, transform.rotation);
        EnemyController1 enemyController1 = enemy.GetComponent<EnemyController1>();
        enemy.GetComponent<EnemyController1>().heartPrefab = heartPrefab;
        enemy.GetComponent<EnemyController1>().audioPoof = audioPoof;
        enemy.GetComponent<EnemyController1>().explosion = explosion;
        enemy.GetComponent<EnemyController1>().player = player;
        enemy.GetComponent<EnemyController1>().playerController = playerController;


        if (enemiesSpawned >= maxEnemies)
        {
            CancelInvoke();
        }
    }
}
