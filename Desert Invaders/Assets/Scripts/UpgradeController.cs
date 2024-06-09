using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerController player;
    public Timer timer;

    void Start()
    {

        if (PlayerPrefs.GetInt("VelocityIncreased", 0) == 1)
        {
            player.moveSpeed *= 2;
            player.velocityIncreasedApplied = true;
        }

        if (PlayerPrefs.GetInt("TripleShoot", 0) == 1)
        {
            player.hasTripleShoot = true;
        }

        if (PlayerPrefs.GetInt("IncreasedDead", 0) == 1)
        {
            player.enemiesDestroyed += 1;
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
            player.hasIncreasedCure = true;
        }

        
        if (PlayerPrefs.GetInt("IncreasedTime", 0) == 1)
        {
            timer.levelTime += 30;
            timer.hasIncreasedTime = true;
        }
    }
    public void IncreaseVelocity()
    {
        if (!player.velocityIncreasedApplied)
        {
            player.moveSpeed *= 2;
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
            int beforeIncreased = player.enemiesDestroyed;
            player.enemiesDestroyed = beforeIncreased + 1;
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
            player.hasIncreasedCure = true;
            PlayerPrefs.SetInt("IncreasedCure", 1);
        }
    }

    public void TimeIncreased()
    {
        if (!timer.hasIncreasedTime)
        {
            timer.levelTime += 30;
            timer.hasIncreasedTime = true;
            PlayerPrefs.SetInt("IncreasedTime", 1);
        }


    }
}
