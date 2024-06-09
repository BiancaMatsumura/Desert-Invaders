using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startDelay;
    public float interval;
    public int enemiesSpawned;
    public int maxEnemies;

    public GameObject enemyPrefab;
    public GameObject flowerPrefab;
    public GameObject explosion;
    public GameObject heartPrefab;
    public AudioSource audioFlowerShoot;
    public AudioSource audioPoof;
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
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemy.GetComponent<EnemyController>().heartPrefab = heartPrefab;
        enemy.GetComponent<EnemyController>().audioFlowerShoot = audioFlowerShoot;
        enemy.GetComponent<EnemyController>().audioPoof = audioPoof;
        enemy.GetComponent<EnemyController>().explosion = explosion;
        enemy.GetComponent<EnemyController>().flowerPrefab = flowerPrefab;
        enemy.GetComponent<EnemyController>().player = player;
        enemy.GetComponent<EnemyController>().playerController = playerController;
        enemy.GetComponent<EnemyController>().firePoint = enemy.transform.Find("firePoint");

        if (enemiesSpawned >= maxEnemies)
        {
            CancelInvoke();
        }
    }
}
