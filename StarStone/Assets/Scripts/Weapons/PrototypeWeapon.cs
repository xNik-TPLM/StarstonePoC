using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is a child of the weapon base
/// The prototype weapon will shoot elemental projectles, which are picked up from the Starstones. This will shoot physical projectiles, instead of using raycasts
/// Worked By: Nikodem Hamrol
/// </summary>

public class PrototypeWeapon : WeaponBase
{
    //Prototype weapon properties
    [Header("Elemental Projectiles")]
    [Tooltip("This is the projectile that prototype weapon is currenty using. Only for debugging")]
    public GameObject ProjectileToFire; //This game object is the projectile that will be fired

    //These game objects are prefabs of each elemental projectile
    [Tooltip("Fire projectile prefab")]
    public GameObject FireProjectile;
    [Tooltip("Earth projectile prefab")]
    public GameObject EarthProjectile;

    //This function is overridden to change the way this weapon fires as it uses physical projectiles
    protected override void PlayerShooting()
    {
        //If there's ammo in this weapon
        if (CurrentAmmo > 0)
        {
            //When the player fires their prototype weapon
            if (Input.GetButtonDown("Fire1"))
            {
                //Instantiate the projectile and decrement ammo by one
                GameObject projectile = Instantiate(ProjectileToFire);
                CurrentAmmo -= 1;

                //Instantiate the projectile at the muzzle position
                projectile.transform.position = WeaponMuzzle.transform.position;
                projectile.transform.rotation = WeaponMuzzle.transform.rotation;
            }
        }

        //Set the projectile based on the Starstone it was interacted
        SetPrototypeProjectile();
    }

    //This function will set the projectiles for the prototype weapon
    private void SetPrototypeProjectile()
    {
        //This switch will set the prototype weapon based on Starstone it was interacted
        switch (InteractStarStone.StarStoneID)
        {            
            case 1: //Earth Starstone, sets the earth projectile
                ProjectileToFire = EarthProjectile;
                break;

            case 2: //Fire Starstone, sets the fire projectile
                ProjectileToFire = FireProjectile;
                break;
        }
    }
}
