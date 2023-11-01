using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueContent
{
    [SerializeField] private string speaker;
    [SerializeField] [TextArea(15,20)] private string  dialgoueText;
    [SerializeField] private int spriteIndex;

    public string Speaker => speaker;
    public string DialogueText => dialgoueText;

    public int SpriteIndex => spriteIndex;
}
