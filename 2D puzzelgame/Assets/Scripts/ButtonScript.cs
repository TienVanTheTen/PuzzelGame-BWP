using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] bool stokOnly;
    bool pressed = false;
    const string STOK_TAG = "Stok";
    public UnityEvent OnButtonClick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pressed) return;
       
        if (stokOnly)
        {
            if (collision.CompareTag(STOK_TAG))
            {
                OnButtonClick?.Invoke();
                buttonPressed();
            }
        }
        else
        {
            OnButtonClick?.Invoke();
            buttonPressed();
        }
        
    }

     void buttonPressed()
    {
        
        pressed = true;
        transform.localPosition = new Vector2(transform.localPosition.x,transform.localPosition.y - .3f); 
    }
}
