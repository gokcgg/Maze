using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public RectTransform screen;


    // The time at which the animation started.

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
        // transform.Translate(screen.position.x, screen.position.y, 0);
        transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 100);
        
    }
   
}
