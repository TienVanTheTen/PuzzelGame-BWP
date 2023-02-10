using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StokScript : MonoBehaviour
{
    private int IndexLayerPickup;
    private int IndexLayerPlayer;
    void Start ()
    {
        IndexLayerPickup = LayerMask.NameToLayer("Pickup");
        IndexLayerPlayer = LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != IndexLayerPickup && collision.gameObject.layer != IndexLayerPlayer)
        {
            Destroy(gameObject);
        }
    }
}
