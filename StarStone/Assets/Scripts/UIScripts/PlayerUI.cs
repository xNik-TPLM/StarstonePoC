using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script handles the player's defensive ability activating a shield to give the player extra health
/// Worked By: Ben Smith
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [Header("Ammo Display")]
    [Tooltip("This displays the text")]
    public Text ammoDisplay; // This displays the current ammo left in the clip
    public Text maxAmmo; // This displays the maximum ammo that is left that the player has

    [Header("Shield Slider And Properties")]
    [Tooltip("This checks whether the shield has been used")]
    public static bool shieldActive; // This checks if the shield is currently enabled
    public Slider shieldSlider; // This sets a reference for the shield bar

    [Header("Health Slider And Properties")]
    public Slider healthSlider; // This sets a reference for the health bar
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); // This enables the Player UI
    }

    // Update is called once per frame
    void Update()
    {

        ammoDisplay.text = FindObjectOfType<WeaponBase>().CurrentAmmo.ToString(); // This displays the current ammo left in the clip as a part of the player's HUD
        maxAmmo.text = FindObjectOfType<WeaponBase>().MaxAmmo.ToString(); // This displays the maximum ammo left in the weapon as a part of the player's HUD
    }
}