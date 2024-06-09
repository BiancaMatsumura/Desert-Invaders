using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerProjectileController : MonoBehaviour
{
    public float speed;
    public int flowerDamage;
    public float lifeTime = 5f;
    public Transform player;

    public PlayerController playerController;
    public EnemyController enemyController;

    void Start()
    {
        flowerDamage = enemyController.damage;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.PlayerTakeDamege(flowerDamage);
        }
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
    }
}
