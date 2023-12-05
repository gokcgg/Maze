using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour, ICollectable
{
    public static event Action OnMapCollected;

    public void Collect()
    {
        OnMapCollected?.Invoke();
        Destroy(gameObject);
        
    }
}
