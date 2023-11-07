using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreatmentMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 heldUpPos;

    public Vector3 heldDownPos;
    public bool draggingTreatment = false;

    // Update is called once per frame
    void Update()
    {
        draggingTreatment =   CheckTreatment();
    }

    public bool CheckTreatment()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Treatments>())
            {
                if(transform.GetChild(i).GetComponent<Treatments>().isDragging)
                    return true;
            }
        }
        return false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(HoldUp());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!draggingTreatment)
        {
            StopAllCoroutines();
            StartCoroutine(PutDown());
        }
            
    }

    public IEnumerator HoldUp( )
    {
        Vector3 initialPosition = GetComponent<RectTransform>().localPosition;
        float duration = 0.3f;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            GetComponent<RectTransform>().localPosition = Vector3.Lerp(initialPosition, heldUpPos, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        GetComponent<RectTransform>().localPosition = heldUpPos;
    }
    public IEnumerator PutDown( )
    {
        Vector3 initialPosition = GetComponent<RectTransform>().localPosition;
        float duration = 0.3f;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            GetComponent<RectTransform>().localPosition = Vector3.Lerp(initialPosition, heldDownPos, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        GetComponent<RectTransform>().localPosition = heldDownPos;
    }
}
