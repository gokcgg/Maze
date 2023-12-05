using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Key : MonoBehaviour, ICollectable
{
    public static event Action OnKeyCollected;
 
    public void Collect()
    {
        Destroy(gameObject);
        OnKeyCollected?.Invoke();
    }
}
