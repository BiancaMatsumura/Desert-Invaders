using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    public int life;
    public float lifeTime;
    public int damage;
  
    public float speed;
    public float stopRange;

    public AudioSource audioPoof;
    public GameObject explosion;
    public GameObject heartPrefab;
    public Transform player;
    public PlayerController playerController;
 

    void Start()
    {
        
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.PlayerTakeDamege(damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            audioPoof.Play();
            playerController.EnemiesDestroyed();
           
        }
    }

    public void EnemyTakeDamage(int damageAmaout)
    {
        life -= damageAmaout;
        if(life <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(heartPrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
            audioPoof.Play();
            playerController.EnemiesDestroyed();
            
        }
    }
}
