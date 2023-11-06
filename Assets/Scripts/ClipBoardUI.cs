using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ClipBoardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    void OnEnable()
    {
        LinkHandler.OnLearnInfo += OnAddInfo;
        DialogueUI.OnNextCharacter += ClearBoard;
    }


    void OnDisable()
    {
        LinkHandler.OnLearnInfo -= OnAddInfo;
        DialogueUI.OnNextCharacter -= ClearBoard;
    }


    void OnAddInfo(string info)
    {
        StopAllCoroutines();
        StartCoroutine(AddInfo(info));
    }

    IEnumerator AddInfo(string info)
    {
        StartCoroutine(HoldUp());
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.PlaySFX(writing);
        if (!infos.Contains(info) && infos.Count < texts.Count)
        {
            infos.Add(info);
            texts[infos.Count - 1].text = info;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(PutDown());
    }

    private List<TMP_Text> texts = new List<TMP_Text>();

    public List<string> infos = new List<string>();

    public Transform clipboard;

    public Vector3 heldUpPos;

    private Vector3 heldDownPos;

    public AudioClip writing;
    // Start is called before the first frame update
    void Start()
    {
        infos.Clear();

        for (int i = 0; i < clipboard.childCount; i++)
        {
            texts.Add(clipboard.GetChild(i).GetComponent<TMP_Text>());
        }
        foreach (var text in texts)
        {
            text.text = String.Empty;
        }

        heldDownPos = GetComponent<RectTransform>().localPosition;
    }

    public void ClearBoard()
    {
        foreach (var text in texts)
        {
            text.text = String.Empty;
        }
        infos.Clear();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(HoldUp());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(PutDown());
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
