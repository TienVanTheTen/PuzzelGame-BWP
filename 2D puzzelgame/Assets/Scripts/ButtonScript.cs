using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] bool stokOnly;
    bool pressed = false;
    const string STOK_TAG = "Stok";
    [SerializeField] GameObject topPartButton;
    [SerializeField] float pressDepth;
    private int layerIndexGround;
    public UnityEvent OnButtonClick;
    public UnityEvent OnButtonRelease;
    Vector2 startButtonPos;
    private void Start()
    {
        startButtonPos = topPartButton.transform.localPosition;
        layerIndexGround = LayerMask.NameToLayer("Ground");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pressed) return;
        if (collision.gameObject.layer == layerIndexGround) return;

        if (stokOnly)
        {
            if (collision.CompareTag(STOK_TAG))
            {
                OnButtonClick?.Invoke();
                ButtonPressed();
            }
        }
        else
        {
            OnButtonClick?.Invoke();
            ButtonPressed();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!pressed) return;
        if (stokOnly) return;
        if (collision.gameObject.layer == layerIndexGround) return;
        
        OnButtonRelease?.Invoke();
        ButtonReleased();


    }

    void ButtonPressed()
    {
        
        topPartButton.transform.localPosition = new Vector2(transform.localPosition.x,transform.localPosition.y - pressDepth/10);
        pressed = true;
    }

    private void ButtonReleased()
    {
     pressed = false;
     topPartButton.transform.localPosition = startButtonPos;   
    }
}
