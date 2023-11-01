using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueContent
{
    [SerializeField] private string speaker;
    [SerializeField] [TextArea] private string  dialgoueText;
    [SerializeField] private int spriteIndex;

    public string Speaker => speaker;
    public string DialogueText => dialgoueText;

    public int SpriteIndex => spriteIndex;
}
