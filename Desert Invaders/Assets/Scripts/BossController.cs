using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int life;
    public Slider lifeSlider;

    public int damage;
    public GameObject flowerPrefab;
    public Transform firePoint;
    
    public PlayerController playerController;
    public Transform player;
    public float initialTimeShoot;
    public float intervalShoot;

    public float speed = 1.0f;

    public Transform pointA;
    public Transform pointB;

    public GameObject victoryPanel;
    private bool firstDeath = false;

 
    
    void Start()
    {
         InvokeRepeating("Shoot", initialTimeShoot, intervalShoot);
   
    }

  
    void Update()
    {
        lifeSlider.value = life;
        BossMove();
    }

    public void BossMove()
    {
        float distanceToMove = Vector3.Distance(pointA.position, pointB.position);
        float time = Time.time * speed;
        float pingPong = Mathf.PingPong(time, distanceToMove);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, pingPong / distanceToMove);
    }

    public void BossTakeDamage(int damageAmaout)
    {
        life -= damageAmaout;

        if (firstDeath)
        {
            
            if (life <= 0)
            {
                Destroy(gameObject);
                victoryPanel.SetActive(true);
            }
        }
        else
        {
            if (life <= 0)
            {
                life = 500;
                firstDeath = true;
            }
        }
    }

    public void Shoot()
    {
        
        GameObject projectile = Instantiate(flowerPrefab, firePoint.position, Quaternion.identity);
        FlowerProjectileController projectileController = projectile.GetComponent<FlowerProjectileController>();
        projectileController.flowerDamage = damage;
        projectileController.bossController = this;
        projectileController.player = player;
        projectileController.playerController = playerController;
    }

    public void Shoot1()
    {
        for (int i = 0; i <= 2; i++)
        {

            float spreadAngle = 15;
            GameObject projectile = Instantiate(flowerPrefab, firePoint.position, Quaternion.identity);
            FlowerProjectileController projectileController = projectile.GetComponent<FlowerProjectileController>();
            projectileController.flowerDamage = damage;
            projectileController.bossController = this;
            projectileController.player = player;
            projectileController.playerController = playerController;

            float rotationAngle = spreadAngle * (i - 1);
            projectile.transform.Rotate(0, rotationAngle, 0);

        }

    }



}


