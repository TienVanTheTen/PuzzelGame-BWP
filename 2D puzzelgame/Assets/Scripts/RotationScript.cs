using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    Rigidbody2D rb;
    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.angularVelocity = rb.velocity.x * -100;
        Debug.Log(rb.velocity.x);
    }
}
