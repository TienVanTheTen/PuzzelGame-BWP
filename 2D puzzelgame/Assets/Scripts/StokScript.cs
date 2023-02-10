using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StokScript : MonoBehaviour
{
    void awake()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
