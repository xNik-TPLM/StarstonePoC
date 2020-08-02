using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementalEnemy : EnemyBase
{
    //Fire elemental enemy fields
    //This float is the time that enemy will shot the projectile
    private float m_enemyTimeToFire;

    //Fire enemy properties
    [Header("Fire Elemental Enemy Properties")]
    [Tooltip("This is the distance the enemy can its projectile at the player")]
    public float FiringDistance; //This is the distance between the player and the enemy, which will allow the enemy to shoot at the player
    [Tooltip("This is the maximum time the projectile will spawn")]
    public float EnemyMaxTimeToFire; //This is the time of spawning the projectile
    [Tooltip("This is the projectile prefab that will be fired at the player")]
    public GameObject FireProjectile; //This is what the enemy throw/shoot at the player

    //The start function is overridden to set the time to fire and the stopping distance of the enemy
    protected override void Start()
    {
        base.Start();
        m_enemyTimeToFire = EnemyMaxTimeToFire;
        m_enemyNavMesh.stoppingDistance = FiringDistance;
    }

    //This function is overridden to add a behaviour relating to this enemy type which is firing the fire projectile
    protected override void EnemyBehaviour()
    {
        base.EnemyBehaviour();
        //If the distance between the enemy and the player is less than the firing distance
        if (Vector3.Distance(transform.position, Target.position) < FiringDistance)
        {
            Debug.Log("In Range");
            isPlayerInRange = true; //Set the bool that the player is in range
            transform.position = transform.position; //Stop the enemy in its position
        }
        else
        {
            isPlayerInRange = false; //Else, set the bool that the player is not in range, which will start moving towards the player again
        }

        //Check if the time to fire is less than or equal to 0 and that the player is in range
        if (m_enemyTimeToFire <= 0 && isPlayerInRange)
        {
            //Spawn the earth boulder and set the time to fire to enemy fire rate property
            Instantiate(FireProjectile, transform.position, transform.rotation);
            m_enemyTimeToFire = EnemyMaxTimeToFire;
        }
        else //If the time to fire is bigger than 0, then count down the time to fire
        {
            m_enemyTimeToFire -= Time.deltaTime;
        }
    }
}
