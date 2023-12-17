using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public UnityEvent onDeath; 
// Start is called before the first frame update
    void Start()
    {
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);

    }
// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
        if ( currentHealth <= 0 )
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
        // every 10 seconds you will gain 1 health if you are below 100 health
        if (Time.frameCount % 600 == 0 && currentHealth < 100){
            Heal(1);
        }
    }

    void TakeDamage (int damage)
    {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    }
    // New function to heal the player
    public void Heal(int healAmount)
    {
        // Ensure healing doesn't exceed the maximum health
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);

        // Update the health bar
        healthBar.SetHealth(currentHealth);
    }
}