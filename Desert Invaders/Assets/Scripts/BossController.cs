using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int life;
    public int secondLife;
    public Slider lifeSlider;

    public int lifeTriple;
    public int secondLifeTriple;

    public int damage;
    public int secondDamage;
    public GameObject flowerPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    
    public PlayerController playerController;
    public Transform player;
    public float initialTimeShoot;
    public float intervalShoot;

    public float initialTimeShoot2;
    public float intervalShoot2;

    public float speed = 1.0f;
     

    public Transform pointA;
    public Transform pointB;

    public GameObject victoryPanel;
    private bool firstDeath = false;
    private bool isInSecondPattern = false;
    private int currentShoot = 0;

    private GameObject explosion;

    public DialogueController dialogueController;
    void Start()
    {
        explosion = transform.Find("CFXR2 Firewall A").gameObject;

        InvokeRepeating("ShootPattern", initialTimeShoot, intervalShoot);
        
        lifeSlider.maxValue = life;

        if (playerController.hasTripleShoot)
        {
            life = lifeTriple;
            secondLife = secondLifeTriple;
        }

    }

  
    void Update()
    {

        lifeSlider.value = life;
        BossMove();

        if (firstDeath && !isInSecondPattern) 
        {
            StartCoroutine(StartSecondPattern());

        }

    }

    IEnumerator StartSecondPattern()
    {
        isInSecondPattern = true;
        CancelInvoke("ShootPattern");
        damage += secondDamage;

        yield return new WaitForSeconds(initialTimeShoot2);

        while (isInSecondPattern)
        {
            ShootPattern();
            yield return new WaitForSeconds(intervalShoot2);
        }
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
                Time.timeScale = 0f;
            }
        }
        else
        {
            if (life <= 0)
            {
                life = secondLife;
                lifeSlider.maxValue = secondLife;
                firstDeath = true;
                explosion.SetActive(true);
                dialogueController.ShowDialogueByIndex(7);
            }
        }
    }

    void ShootPattern()
    {
        switch (currentShoot)
        {
            case 0:
                Shoot();
                currentShoot++;
                break;
            case 1:
                Shoot1();
                currentShoot++;
                break;
            case 2:
                Shoot2();
                currentShoot = 0;
                break;

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
        projectileController.followPlayer = true;
    }

    public void Shoot1()
    {
        int numberOfBullets = 20;
        float bulletSpeed = 15f;
        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float bulletDirectionX = firePoint.forward.x * Mathf.Cos(angle * Mathf.Deg2Rad) - firePoint.forward.z * Mathf.Sin(angle * Mathf.Deg2Rad);
            float bulletDirectionZ = firePoint.forward.x * Mathf.Sin(angle * Mathf.Deg2Rad) + firePoint.forward.z * Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 bulletMoveDirection = new Vector3(bulletDirectionX, 0, bulletDirectionZ);

            GameObject projectile = Instantiate(flowerPrefab, firePoint2.position, Quaternion.identity);
            FlowerProjectileController projectileController = projectile.GetComponent<FlowerProjectileController>();
            projectileController.flowerDamage = damage;
            projectileController.bossController = this;
            projectileController.player = player;
            projectileController.playerController = playerController;
            
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = bulletMoveDirection * bulletSpeed;

            angle += angleStep;
        }

    }

    public void Shoot2()
    {
        int numberOfBullets = 6;
        float spreadAngle = 55f;
        float projectileSpeed = 10;
        float angleStep = spreadAngle / (numberOfBullets - 1);
        float angle = -spreadAngle / 2;

        for (int i = 0; i < numberOfBullets; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 bulletDirection = rotation * -firePoint2.forward;

            Vector3 bulletMoveDirection = new Vector3(bulletDirection.x, 0, bulletDirection.z);
            GameObject projectile = Instantiate(flowerPrefab, firePoint2.position, Quaternion.identity);
            FlowerProjectileController projectileController = projectile.GetComponent<FlowerProjectileController>();
            projectileController.flowerDamage = damage;
            projectileController.bossController = this;
            projectileController.player = player;
            projectileController.playerController = playerController;

            projectile.GetComponent<Rigidbody>().velocity = bulletMoveDirection.normalized * projectileSpeed; 

            angle += angleStep;
        }
    }


}


