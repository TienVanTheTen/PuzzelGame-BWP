using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTextScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;




    public void DisplayTutorial(string text, float duration)
    {
        StartCoroutine(text, duration);
    }

    void Update()
    {

    }
    public IEnumerator DisplayTutorialText(string text, float duration)
    {
        textComponent.text = text;
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
