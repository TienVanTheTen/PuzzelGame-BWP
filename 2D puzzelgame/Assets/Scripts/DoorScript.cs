using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private float closingDuration;
    [SerializeField] private Vector2 offset;
    private Vector2 closedPos;
    private Vector2 openPos;
    private void Start()
    {
        closedPos = transform.position;
    }
    public void OpenDoor()
    {
        StopAllCoroutines();
        openPos = closedPos + offset;
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
