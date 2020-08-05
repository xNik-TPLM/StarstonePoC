using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is how the player will interact with the Starstones that surround the generator in order to the change to different elemental projectiles for the prototype weapon.
/// Worked By: Nikodem Hamrol
/// </summary>

public class InteractStarStone : MonoBehaviour
{
    //Starstone fields
    //Static fields
    public static int StarStoneID; //This integer represents the element of the Starstone, which will give the correct projectile to the prototype weapon
    public static int WeaponID; //This integer represents the weapon in the weapon holder


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //When a player enters and stays within a Starstone, box trigger
    private void OnTriggerStay(Collider trigger)
    {
        //Check the tag for the player
        if (trigger.CompareTag("Player"))
        {
            //When the player presses E to interact
            if (Input.GetButtonDown("Interact"))
            {
                //Based on the name of the Starstone elemental, set the Starstone ID to use that elemental projectile
                switch (gameObject.name)
                {
                    case "EarthStarStone":
                        StarStoneID = 1;
                        break;

                    case "FireStarStone":
                        StarStoneID = 2;
                        break;
                }

                //Set the weapon ID to the prototype weapon and display it
                WeaponID = 1;
                FindObjectOfType<WeaponsSelect>().SetWeapon();
            }

        }
    }


}
