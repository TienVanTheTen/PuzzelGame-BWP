using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;


public class GrabObjects : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layerIndex;

    private GameObject grabbedObject;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.forward, rayDistance, layerIndex);
        if (!hitInfo)
            return;

        if (hitInfo.collider != null)
        {

            //grab the object

            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {

                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);


            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;

            }






        }

    }
}
