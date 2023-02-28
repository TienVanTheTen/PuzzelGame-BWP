using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogScript : MonoBehaviour
{
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public AudioClip[] clips;
        public AudioSource audioSource;
        public float textSpeed;

        private int index;


        // Start is called before the first frame update
        void Start()
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    nextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            // Type each character one by one
            AudioClip audioClip = clips[index];
            if (audioClip)
            {
                audioSource.PlayOneShot(audioClip);

            }

            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;

                yield return new WaitForSeconds(textSpeed);
            }
        }

        void nextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }


