using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is a child to the enemy base.
/// This is a Wind Elemental enemy. Its faster than any other enemy and it attacks by detonating on when the player is within the proximity
/// Worked By: Nikodem Hamrol
/// References: Digital Ruby (Johnson, J.). (2018). Fire & Spell Effects. [online]. Available: https://assetstore.unity.com/packages/vfx/particles/fire-explosions/fire-spell-effects-36825 [Last accessed 19th July 2020].
/// </summary>

public class WindElementalEnemy : EnemyBase
{
    //Wind elemental enemy fields
    //This boolean checks if player is in detonation range, which will detonate the enemy dealing damage to the player, if it's in the area.
    private bool m_isPlayerInDetonationRange;

    //This float is the time of detonation that will be counting up until it reaches maxs detonation time
    private float m_detonationTime;

    [Header("Wind Elemental Properties")]
    [Tooltip("This is the maximum time for detonation")]
    public float MaxDetonationTime; //This is the max timebefore the enemy will detonate

    //This function is overridden to deal different damage based on the elemental projectile
    public override void EnemyDamaged(float damage, int projectileType)
    {
        base.EnemyDamaged(damage, projectileType);

        //The projectile type will determine what sort of damage will it do this enemy
        switch (projectileType)
        {
            case 1: //Earth projectile will deal normal damage and will give the player some health
                CurrentHealth -= damage;
                break;

            case 2: //Fire projectile will deal double damage, with the addition of burning damage
                CurrentHealth -= damage * 2;
                m_isEnemyBurning = true;
                break;
        }
    }

    //This function is overridden to add a behaviour relating to this enemy type which is the detonation
    protected override void EnemyBehaviour()
    {
        base.EnemyBehaviour();
        EnemyDetonation();
    }

    //When a player enters and stays within the enemy's sphere collider
    private void OnTriggerEnter(Collider other)
    {
        //Check if the object is tagged as player
        if (other.CompareTag("Player"))
        {
            //Set the plaer is in range, which will initiate the detonation function
            m_isPlayerInDetonationRange = true;
            Debug.Log("Start Detonation");
        }
    }

    //This function will handle the detonation of the enemy
    private void EnemyDetonation()
    {
        //Check if the player is in detonation range
        if (m_isPlayerInDetonationRange == true)
        {
            //Set player in range to true, which will stop the player and start counting the detonation time
            isPlayerInRange = true;
            m_detonationTime += Time.deltaTime;

            //If the detonation time is above the max detonation time, kill the enemy
            if (m_detonationTime > MaxDetonationTime)
            {
                CurrentHealth = 0;
                Debug.Log("Enemy Detonated");
            }
        }
    }
}
