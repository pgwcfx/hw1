using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public Dropdown difficultyDropdown; //creates a dropdown button
    public static float speedMultiplier = 1f; //creates initial speed multiplier

    public void SetDifficulty(int difficulty)
    {
        switch (difficulty) //different speed based on what difficulty is selected
        {
            case 0:
                speedMultiplier = 2.0f;
                break;
            case 1:
                speedMultiplier = 5.0f;
                break;
            case 2:
                speedMultiplier = 10.0f;
                break;
            default:
                speedMultiplier = 1.0f;
                break;
        }
        UpdatePickupSpeeds(); //update speed
    }

    void UpdatePickupSpeeds()
    {
        PickupMovements[] pickups = FindObjectsOfType<PickupMovements>(); //find all pickup objects
        foreach (PickupMovements pickup in pickups)
        {
            pickup.SetSpeedByDifficulty(); //update all pickup objects speed at once
        }
    }
}
