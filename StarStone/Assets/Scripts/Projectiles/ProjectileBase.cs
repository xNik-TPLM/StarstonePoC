﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is a base script for projectiles in the game.
/// It will mainly check collision against objects, such as enemies and player. It also holds properties, such as projectile speed and damage.
/// Worked By: Nikodem Hamrol
/// References: Gabriel Aguiar Prod. (2018). Unity 2018 - Game VFX - Projectile/Bullet Raycast Tutorial [online]. Available: https://www.youtube.com/watch?v=xenW67bXTgM [Last Accessed 9th June June 2020].
/// </summary>

public class ProjectileBase : MonoBehaviour
{
    //Projectile field
    //This float will get the property value of a projectile duration and uses it to count down the life of a projectile
    private float m_projectileLifeTimer;

    //Projectile properties
    //Flaot properties
    [Tooltip("This is duration of the projectile can be on scene in seconds")]
    public float ProjectileDuration; //This is the duration of each projectile that will get instantiated
    [Tooltip("This is the speed the projectile can travel")]
    public float ProjectileSpeed; //The speed of the projectile
    [Tooltip("This is the amount of damage a projectile can deal")]
    public float ProjectileDamage; //The damage the that the projectile will deal to the target

    // Start is called before the first frame update
    void Start()
    {
        //Set the the timer using the duration property
        m_projectileLifeTimer = ProjectileDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the direction of the projectile which will be travelling
        transform.position += transform.forward * ProjectileSpeed * Time.deltaTime;

        //Count down the life of the projectile
        m_projectileLifeTimer -= Time.deltaTime;

        //if the time runs out then it will destroy the projectile
        if(m_projectileLifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Using the trigger for the projectile instead of "OnCollisioEnter", because there is no rigidbody on the bullet
    private void OnTriggerEnter(Collider other)
    {
        //If the bullet enters the enemy's collider then it will destroy the bullet
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }
    }
}
