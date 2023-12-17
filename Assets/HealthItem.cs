using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10;  // The amount of health to give
    

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Give health to the player
            other.GetComponent<QueenLife>().Heal(healthAmount);

            // Destroy the health item
            Destroy(gameObject);
        }
    }
}
