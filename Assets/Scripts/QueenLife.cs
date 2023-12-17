using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QueenLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public QueenHealth healthBar;
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
        // every 10 seconds the queen will lose 1 health
        if (Time.frameCount % 600 == 0){
            TakeDamage(1);
        }
        if ( currentHealth <= 0 )
        {
            onDeath.Invoke();
            Destroy(gameObject);
            //lose screen here


        }

    }

    void TakeDamage (int damage)
    {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    }
    public void Heal(int healAmount)
    {
        // Ensure healing doesn't exceed the maximum health
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);

        // Update the health bar
        healthBar.SetHealth(currentHealth);
    }
}
