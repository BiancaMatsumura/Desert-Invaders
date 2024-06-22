using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerProjectileController : MonoBehaviour
{
    public float speed;
    public int flowerDamage;
    public float initialMoveDuration = 0.5f;
    public float lifeTime = 5f;
    public Transform player;

    public PlayerController playerController;
    public EnemyController enemyController;
    public BossController bossController;

  
    public bool followPlayer;
   
    void Start()
    {
        if(enemyController != null) 
        {
            flowerDamage = enemyController.damage;
        }
        else
        {
            flowerDamage = bossController.damage;
        }
       
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
       if (followPlayer && player != null)
        {
           
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.PlayerTakeDamege(flowerDamage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
    }

}
