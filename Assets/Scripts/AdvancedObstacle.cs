using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdvancedObstacle : MonoBehaviour, IObstacle
{
    public static event Action OnAdvancedDamage;
    
    public void GetDamage()
    {
        OnAdvancedDamage?.Invoke();
        gameObject.GetComponent<Collider>().gameObject.SetActive(false);
    }
}
