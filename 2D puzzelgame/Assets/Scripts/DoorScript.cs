using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private float closingDuration;
    [SerializeField] private Vector2 closedPos;
    [SerializeField] private Vector2 openPos;
    
    public void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(transform.position, openPos));
        
    }
    public void CloseDoor()
    {
        
        StopAllCoroutines();
        StartCoroutine(MoveDoor(transform.position, closedPos));
    }
    private IEnumerator MoveDoor(Vector2 startPos, Vector2 endPos)
    {
        float time = 0f;
        while (time <= 1.0)
        {
            time += Time.deltaTime / closingDuration;
            transform.position = Vector2.Lerp(startPos, endPos, time);
            yield return null;

        }
        
    }

}
