using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life2 : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath; 

    void Update()
    {
        if ( amount <= 0 )
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
