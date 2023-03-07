using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorialScript : MonoBehaviour
{
    public event Action<TriggerTutorialScript> OnTutorialTrigger;
    
    [SerializeField] private float duration;
    [SerializeField] private string text;

    public float Duration => duration;
    public string Text => text;

    private bool displayed = false;
    private const string PLAYER_TAG = "Player";



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG) && !displayed)
        {
            OnTutorialTrigger?.Invoke(this);
            displayed = true;
        }
    }

}
