using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicObstacle : MonoBehaviour, IObstacle
{
    public static event Action OnBasicDamage;

    public void GetDamage()
    {
        OnBasicDamage?.Invoke();
    }
}
