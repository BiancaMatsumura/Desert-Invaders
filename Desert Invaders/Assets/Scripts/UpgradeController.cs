using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerController player;
    public Timer levelTimer;

    void Start()
    {

        if (PlayerPrefs.GetInt("VelocityIncreased", 0) == 1)
        {
            player.moveSpeed += 4;
            player.velocityIncreasedApplied = true;
        }

        if (PlayerPrefs.GetInt("TripleShoot", 0) == 1)
        {
            player.hasTripleShoot = true;
        }

        if (PlayerPrefs.GetInt("IncreasedDead", 0) == 1)
        {
           
            player.deadIncreasedApplied = true;
        }

        if (PlayerPrefs.GetInt("IncreasedShield", 0) == 1)
        {
            player.shieldTime += 5;
            player.hasIncreasedShield = true;
        }

        if (PlayerPrefs.GetInt("IncreasedCure", 0) == 1)
        {
            player.cure += 5;
            player.life += 50;
            player.hasIncreasedCure = true;
        }

        
        if (PlayerPrefs.GetInt("IncreasedTime", 0) == 1)
        {
            levelTimer.levelTime += 30;
            levelTimer.hasIncreasedTime = true;
        }
    }


    public void ResetUpgrades()
    {
        PlayerPrefs.DeleteKey("VelocityIncreased");
        PlayerPrefs.DeleteKey("TripleShoot");
        PlayerPrefs.DeleteKey("IncreasedDead");
        PlayerPrefs.DeleteKey("IncreasedShield");
        PlayerPrefs.DeleteKey("IncreasedCure");
        PlayerPrefs.DeleteKey("IncreasedTime");

    }



    public void IncreaseVelocity()
    {
        if (!player.velocityIncreasedApplied)
        {
            player.moveSpeed += 4;
            player.velocityIncreasedApplied = true;
            PlayerPrefs.SetInt("VelocityIncreased", 1);
        }
    }

    public void TripleShoot()
    {
        player.hasTripleShoot = true;
        PlayerPrefs.SetInt("TripleShoot", 1);
    }

    public void IncreasedDead()
    {
        if(!player.deadIncreasedApplied)
        {
            player.deadIncreasedApplied = true;
            PlayerPrefs.SetInt("IncreasedDead", 1);
        }
    }

    public void IncreasedShieldTime()
    {
        if (!player.hasIncreasedShield)
        {
            player.shieldTime += 5;
            player.hasIncreasedShield = true;
            PlayerPrefs.SetInt("IncreasedShield", 1);
        }
    }

    public void IncreasedCure()
    {
        if (!player.hasIncreasedCure)
        {
            player.cure += 5;
            player.life += 50;
            player.hasIncreasedCure = true;
            PlayerPrefs.SetInt("IncreasedCure", 1);
        }
    }

    public void TimeIncreased()
    {
        if (!levelTimer.hasIncreasedTime)
        {
            levelTimer.levelTime += 30;
            levelTimer.hasIncreasedTime = true;
            PlayerPrefs.SetInt("IncreasedTime", 1);
        }


    }
}
