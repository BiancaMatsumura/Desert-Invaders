using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    public int life;
    public int damage;
    public float moveSpeed;
    public int enemiesDestroyed;
    public int enemiesToWin = 10;
    public int cure;
    public float shieldTime;

    [Header("Audios")]
    public AudioSource audioItem;
    public AudioSource audioDamage;
    public AudioSource audioPopUp;
    public AudioSource audioShield;
    public AudioSource audioShoot;

    [Header("Panels / UI")]
    public Camera mainCamera;
    public Slider healthSlider;
    public Slider shieldBar;
    public Text enemiesText;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject youFailedPanel;
    public GameObject victoryPanel;

    [Header("Assigments")]
    public GameObject starProjectile;
    public Transform firePoint;
    public DialogueController dialogueController;

    [Header("Upgrade")]
    public bool hasTripleShoot = false;
    public bool velocityIncreasedApplied = false;
    public bool deadIncreasedApplied = false;
    public bool hasIncreasedShield = false;
    public bool hasIncreasedCure = false;

    Rigidbody rig;
    private float currentShieldTime;
    private bool hasShield = false;
    private bool hasWon = false;
    private bool shieldAudioPlayed = false;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        shieldBar.maxValue = shieldTime;
        shieldBar.value = shieldTime;
        currentShieldTime = shieldTime;
        dialogueController.ShowDialogueByIndex(0);

    }


    void Update()
    {
        if (!pausePanel.activeSelf && !victoryPanel.activeSelf && !gameOverPanel.activeSelf && !youFailedPanel.activeSelf && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audioShoot.Play();
        }
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

       
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            transform.Rotate(0, 180, 0);
        }

        healthSlider.value = life;
        enemiesText.text = enemiesDestroyed.ToString("D2");
        

        if (hasShield)
        {
            ActivateShield();
        }
        

        if (!hasWon)
        {
            Victory();
        }
    }

    void FixedUpdate()
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rig.velocity = Position * moveSpeed;
    }

    public void Shoot()
    {
        
        if (hasTripleShoot == false)
        {
          
            GameObject projectile = Instantiate(starProjectile, firePoint.position, firePoint.rotation);
            StarProjectilController projController = projectile.GetComponent<StarProjectilController>();
            projController.playerController = this;
           
        }
        else
        {
           
            for (int i = 0; i <= 3; i++)
            {
                
                float spreadAngle = 15;
                GameObject projectile = Instantiate(starProjectile, firePoint.position, transform.rotation);
                float rotationAngle = spreadAngle * (i - 1);
                projectile.transform.Rotate(0, rotationAngle, 0);
                StarProjectilController projController = projectile.GetComponent<StarProjectilController>();
                projController.playerController = this;

                
            }
        }
    }
    public void TripleShoot()
    {
        for (int i = 0; i <= 3; i++)
        {

            float spreadAngle = 15;
            GameObject projectile = Instantiate(starProjectile, firePoint.position, transform.rotation);
            float rotationAngle = spreadAngle * (i - 1);
            projectile.transform.Rotate(0, rotationAngle, 0);
            StarProjectilController projController = projectile.GetComponent<StarProjectilController>();
            projController.playerController = this;


        }
    }

    public void PlayerTakeDamege(int damageAmount)
    {
        
        if (!hasShield)
        {
            life -= damageAmount;
            audioDamage.Play();
        }
       
        if(life <= 0)
        {
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
            audioPopUp.Play();
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            audioItem.Play();
            Destroy(other.gameObject);
            hasShield = true;
            currentShieldTime = shieldTime;
            shieldBar.maxValue = shieldTime;
            shieldBar.value = shieldTime;
        }
        if(other.gameObject.CompareTag("Life Item")) 
        {
            life += cure;
            audioItem.Play();
            Destroy(other.gameObject);
        }
    }

    public void ActivateShield()
    {
        
        currentShieldTime -= Time.deltaTime;
        shieldBar.value = currentShieldTime;

        Transform childTransform = transform.Find("shieldVSX");
        if (childTransform != null)
        {
            childTransform.gameObject.SetActive(true);
        }

        if (currentShieldTime <= 0)
        {
            
            hasShield = false;
            shieldBar.value = 0;
            childTransform.gameObject.SetActive(false);
            shieldAudioPlayed = false;
        }
        else if (!shieldAudioPlayed)
        {
            audioShield.Play();
            shieldAudioPlayed= true;
        }
    }

    public void Victory()
    {
        if(enemiesDestroyed >= enemiesToWin)
        {
            audioPopUp.Play();
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
            hasWon = true;
        }
    }
}
