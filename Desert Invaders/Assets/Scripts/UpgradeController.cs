using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerController player;
    public Timer timer;

    public bool hasVelocityIncreased = false;
    public bool hasTripleShoot = false;
    public bool hasIncreasedDead = false;
    public bool hasIncreasedShield = false;
    public bool hasIncreasedCure = false;

    public void Update()
    {
        ApplyUpgrade();
    }
    public void ApplyUpgrade() 
    {
        IncreaseVelocity();
        TripleShoot();
        IncreasedDead();
        IncreasedShieldTime();
        IncreasedCure();
    }
    public void IncreaseVelocity()
    {
        if (hasVelocityIncreased && !player.velocityIncreasedApplied)
        {
            player.moveSpeed *= 2;
            player.velocityIncreasedApplied = true;
        }
    }

    public void TripleShoot()
    {
        if(hasTripleShoot)
        {
            player.hasTripleShoot = true;
        }
    }

    public void IncreasedDead()
    {
        if(hasIncreasedDead && !player.deadIncreasedApplied)
        {
            int beforeIncreased = player.enemiesDestroyed;
            player.enemiesDestroyed = beforeIncreased + 1;
            player.deadIncreasedApplied = true;
        }
    }

    public void IncreasedShieldTime()
    {
        if (hasIncreasedShield && !player.hasIncreasedShield)
        {
            player.shieldTime += 5;
            player.hasIncreasedShield = true;
        }
    }

    public void IncreasedCure()
    {
        if (hasIncreasedCure && !player.hasIncreasedCure)
        {
            player.cure += 5;
            player.hasIncreasedCure = true;
        }
    }
}
