using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is just a temporary script for the wave UI. This script will be put into the "PlayerUI" script in the prototype phase
/// Worked By: Nikodem Hamrol
/// </summary>

public class Timer : MonoBehaviour
{
    [Tooltip("This is the text object that displays the wave time")]
    public Text TimerText; //This text object will show the time left for a wave to be completed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Convert the time from an integer to string
        string timerSeconds = ((int)WaveSystem.WaveTimer % 60).ToString("00");
        string timerMinutes = ((int)WaveSystem.WaveTimer / 60).ToString("00");

        //Set timer text
        TimerText.text = "Time: " + timerMinutes + ":" + timerSeconds;
    }
}
