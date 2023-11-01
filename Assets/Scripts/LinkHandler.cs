using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    public delegate void LearnInfoAction(string info);
    public static event LearnInfoAction OnLearnInfo;

    public static bool isKeywordUsed = false;

    [SerializeField] private TMP_Text textBox;

    private void Awake()
    {
        textBox = GetComponent<TMP_Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);

        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(textBox, mousePosition, null);

        if(linkTaggedText != -1 && !isKeywordUsed)
        {
            if(OnLearnInfo != null)
                OnLearnInfo?.Invoke(DialogueUI.currentClipboardInfo);
            isKeywordUsed = true;
        }
    }
}
