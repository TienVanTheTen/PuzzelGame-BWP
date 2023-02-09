using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;


public class GrabObjects : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    
    private int layerIndex;
    private GameObject grabbedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
        layerIndex = LayerMask.NameToLayer("Pickup");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.forward, rayDistance);
        
        if (hitInfo.collider !=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
           
            //grab the object

            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                Debug.Log("baanaan");
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
