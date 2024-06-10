using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life;
    public float lifeTime;
    public int damage;
    public float speed;
    public float stopRange;

    public Transform firePoint;
    public GameObject flowerPrefab;
    public GameObject explosion;
    public AudioSource audioFlowerShoot;
    public AudioSource audioPoof;
    public float startDelay = 1f;
    public float shootInterval = 2f;

    public GameObject heartPrefab;
    public Transform player;
    public PlayerController playerController;
    public FlowerProjectileController flowerProjectileController;

    void Start()
    {
        InvokeRepeating("Shoot", startDelay, shootInterval);
        
    }

    private void Update()
    {
        Destroy(gameObject,lifeTime);

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > stopRange && player.position != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
 
    }
    void Shoot()
    {
        audioFlowerShoot.Play();
        GameObject projectile = Instantiate(flowerPrefab, firePoint.position, firePoint.rotation);
        FlowerProjectileController projectileController = projectile.GetComponent<FlowerProjectileController>();
        projectileController.enemyController = this;
        projectileController.flowerDamage = damage;
        projectileController.playerController = playerController;
        projectileController.player = player;
        
    }
    public void EnemyTakeDamage(int damageAmaout)
    {
        life -= damageAmaout;
        if(life <= 0)
        {
            Instantiate(explosion,transform.position, transform.rotation);
            Instantiate(heartPrefab,transform.position,Quaternion.identity);
            audioPoof.Play();
            Destroy(gameObject);
            playerController.EnemiesDestroyed();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            audioPoof.Play();
            playerController.EnemiesDestroyed();
            
        }
    }
}
