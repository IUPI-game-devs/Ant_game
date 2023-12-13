using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public QueenHealth healthBar;
// Start is called before the first frame update
    void Start()
    {
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
    
    }
// Update is called once per frame
    void Update()
    {
        // every 10 seconds the queen will lose 1 health
        if (Time.frameCount % 600 == 0){
            TakeDamage(1);
        }
    }

    void TakeDamage (int damage)
    {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    }
}
