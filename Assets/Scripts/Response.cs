using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response 
{
    [SerializeField] private string responeText;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private bool Transition;

    public string ResponseText => responeText;

    public DialogueObject DialogueObject => dialogueObject;

    public bool transition => Transition;
}
