using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectilController : MonoBehaviour
{
    public float spd;
    public int projectileDamage;
    public float lifeTime = 5f;

    public PlayerController playerController;
    
   

    private void Start()
    {
        
        projectileDamage = playerController.damage;
        transform.Rotate(90, 0, 0);

        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        
        transform.Translate(0, spd * Time.deltaTime * -1, 0);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.EnemyTakeDamage(projectileDamage);
            }

            EnemyController1 enemyController1 = other.GetComponent<EnemyController1>();
            if (enemyController1 != null)
            {
                enemyController1.EnemyTakeDamage(projectileDamage);
            }

            Destroy(gameObject);
        }
    }



}
