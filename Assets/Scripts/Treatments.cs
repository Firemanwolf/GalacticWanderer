using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Treatments : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Ailments curingAilment;
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    [HideInInspector]private Vector2 originalPos;

    public Canvas canvas;

    public bool isDragging;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();
        originalPos = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta/canvas.scaleFactor;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.localPosition = originalPos;
        isDragging = false;
        GetComponentInParent<TreatmentMenu>().StartCoroutine(GetComponentInParent<TreatmentMenu>().PutDown());
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
