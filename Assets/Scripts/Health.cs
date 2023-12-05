using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, ICollectable
{
    public static event Action OnHealthCollected;
 
    public void Collect()
    {
        
        Destroy(gameObject);
        OnHealthCollected?.Invoke();
    }
}
