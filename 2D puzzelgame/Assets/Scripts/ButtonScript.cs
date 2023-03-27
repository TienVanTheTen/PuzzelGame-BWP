using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] bool stokOnly;
    [SerializeField] private LayerMask triggerLayer;
  
    [SerializeField] GameObject topPartButton;
    [SerializeField] float pressDepth;
    private int layerIndexGround;
    public UnityEvent OnButtonClick;
    public UnityEvent OnButtonRelease;
    bool pressed = false;

    Vector2 startButtonPos;

    private void Start()
    {
        startButtonPos = topPartButton.transform.localPosition;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pressed) return;
        if (((1 << collision.gameObject.layer) & triggerLayer) != 0)
        {

            OnButtonClick?.Invoke();
            ButtonPressed();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!pressed) return;
        if (stokOnly) return;
        if (((1 << collision.gameObject.layer) & triggerLayer) != 0)
        {
            OnButtonRelease?.Invoke();
            ButtonReleased();
        }
    }

    void ButtonPressed()
    {
        pressed = true;
        topPartButton.transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - pressDepth / 10);
    }

    private void ButtonReleased()
    {
        pressed = false;
        topPartButton.transform.localPosition = startButtonPos;
    }
}
