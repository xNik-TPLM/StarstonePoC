using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///// <summary>
///// This script handles the ammo crate to provide the player with more ammo
///// Worked By: Ben Smith
///// </summary>
public class AmmoCrate : MonoBehaviour
{
    // This checks whether the player has picked up the crate
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            FindObjectOfType<WeaponBase>().MaxAmmo += 10; // This adds the ammo to the player's weapon
            gameObject.SetActive(false); // This hides the crate once used
        }
    }
}