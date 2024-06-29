using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsController : MonoBehaviour
{
    public UIController controller;
    public float speed = 50f;
    public float speedUpgrade = 100f;
    public bool inputPressed = false;
    public UpgradeController upgrade;
    
    void Start()
    {
      

    }

    
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
           inputPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputPressed = true;
        }

        if (inputPressed) 
        {

            transform.Translate(Vector2.up * speedUpgrade * Time.deltaTime);

        }

        if (!inputPressed)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if(transform.position.y >= 5500)
        {
            upgrade.ResetUpgrades();
            controller.Load("menu");
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            upgrade.ResetUpgrades();
            controller.Load("menu");
            

        }
    }


}
