using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClipBoardUI : MonoBehaviour
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
        if (!infos.Contains(info))
        {
            infos.Add(info);
            texts[infos.Count - 1].text = info;
        }
    }

    private List<TMP_Text> texts = new List<TMP_Text>();

    public List<string> infos = new List<string>();

    public Transform clipboard;
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
    }

    public void ClearBoard()
    {
        foreach (var text in texts)
        {
            text.text = String.Empty;
        }
        infos.Clear();
    }
}
