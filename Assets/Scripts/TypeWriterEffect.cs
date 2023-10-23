using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 50f;
    public bool textfinished;
    public bool canceltyping;

    private void Start()
    {
        textfinished = true;
        canceltyping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&!textfinished )
        {
            canceltyping = !canceltyping;
        }
    }

    public Coroutine Run(string textToType, TextMeshProUGUI textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType,TextMeshProUGUI textLabel)
    {
       textfinished = false;
        textLabel.text = string.Empty;
        float t = 0;
        int charIndex = 0;
                while (!canceltyping && charIndex < textToType.Length)
                {
                    t += Time.deltaTime * typewriterSpeed;
                    charIndex = Mathf.FloorToInt(t);
                    charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

                    textLabel.text = textToType.Substring(0, charIndex);
                    yield return null;
                }
        textfinished = true;
        textLabel.text = textToType;
        canceltyping = false;      
            }
  
    }

