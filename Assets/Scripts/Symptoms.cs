using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Symptoms : MonoBehaviour , IDropHandler
{
    [SerializeField] Ailments ailment;
    [SerializeField] private Sprite curedCharacter;
    private Image character;

    private void Awake()
    {
        character = transform.parent.GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.TryGetComponent<Treatments>(out Treatments treatment))
            {
                if(treatment.curingAilment == ailment)
                {
                    if(curedCharacter != null)character.sprite = curedCharacter;
                    Destroy(gameObject);
                }
            }
        }
    }
    
}
