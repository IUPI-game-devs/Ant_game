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
    }

    void TakeDamage (int damage)
    {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    }
}