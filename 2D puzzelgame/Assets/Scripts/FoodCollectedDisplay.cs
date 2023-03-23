using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollectedDisplay : MonoBehaviour
{
    [SerializeField] private float displayTime;
    [SerializeField] private string defaultText;
    
    List<string> triggers = new List<string>();
    bool activeDisplay;
    public TextMeshProUGUI textComponent;
    private void Start()
    {
   
    }
    public void DisplayProgress(int progress, float amountOfFoodOnMap)
    {
        string text = progress.ToString();

        if (activeDisplay)
        {
            triggers.Add(text);
        }
        else
        {
            activeDisplay = true;
            StartCoroutine(DisplayprogressText(defaultText + text + "/", displayTime, amountOfFoodOnMap));
        }
        
    }
  
    public IEnumerator DisplayprogressText(string text, float duration, float amountOfFoodOnMap )
    {
        textComponent.text = text + amountOfFoodOnMap;

        float timer = 0;
        bool forward = true;

        while (true)
        {
            float lerpMin = forward ? Mathf.Lerp(1f, 0.75f, timer) : Mathf.Lerp(0.75f, 1f, timer);
            float lerpMax = forward ? Mathf.Lerp(1.25f, 1f, timer) : Mathf.Lerp(1f, 1.25f, timer);

            RectTransform rectTransform = transform as RectTransform;
            rectTransform.anchorMin = new Vector2(lerpMin, rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(lerpMax, rectTransform.anchorMin.y);

            if (rectTransform.anchorMin.x == (forward ? 0.75f : 1f))
            {
                if (!forward)
                {
                    if (triggers.Count > 0)
                    {
                        activeDisplay = true;
                        textComponent.text = defaultText + triggers[0] + "/" + amountOfFoodOnMap;
                        forward = true;
                        timer = 0f;
                        triggers.RemoveAt(0);
                        continue;
                    }
                    activeDisplay = false;
                    break;
                }

                yield return new WaitForSeconds(duration);
                forward = false;
                timer = 0;
            }

            timer += Time.deltaTime;
            yield return null;

        }
    }
}
