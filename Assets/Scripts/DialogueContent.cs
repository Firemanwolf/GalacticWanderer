using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueContent
{
    [SerializeField] [TextArea] private string  dialgoueText;
    [Header("表情1")]
    [SerializeField] private bool shy;
    [SerializeField] private bool angry;
    [SerializeField] private bool happy;
    [SerializeField] private bool sad;
    [Header("表情2")]
    [SerializeField] private bool shy2;
    [SerializeField] private bool angry2;
    [SerializeField] private bool happy2;
    [SerializeField] private bool sad2;
    [SerializeField] private bool idle2;
    [Header("表情3")]
    [SerializeField] private bool shy3;
    [SerializeField] private bool angry3;
    [SerializeField] private bool happy3;
    [SerializeField] private bool sad3;
    [SerializeField] private bool idle3;
    [Header("表情4")]
    [SerializeField] private bool shy4;
    [SerializeField] private bool angry4;
    [SerializeField] private bool happy4;
    [SerializeField] private bool sad4;
    [SerializeField] private bool idle4;
    [Header("表情5")]
    [SerializeField] private bool shy5;
    [SerializeField] private bool angry5;
    [SerializeField] private bool happy5;
    [SerializeField] private bool sad5;
    [SerializeField] private bool idle5;
    [Header("人物进出场")]
    [SerializeField] private bool noavator;

    public string DialogueText => dialgoueText;
    public bool Shy => shy;
    public bool Angry => angry;
    public bool Happy => happy;
    public bool Sad => sad;
    public bool noAvator => noavator;
    public bool Shy2 => shy2;
    public bool Angry2 => angry2;
    public bool Happy2 => happy2;
    public bool Sad2 => sad2;
    public bool Idle2 => idle2;
    public bool Shy3 => shy3;
    public bool Angry3 => angry3;
    public bool Happy3 => happy3;
    public bool Sad3 => sad3;
    public bool Idle3 => idle3;
    public bool Shy4 => shy4;
    public bool Angry4 => angry4;
    public bool Happy4 => happy4;
    public bool Sad4 => sad4;
    public bool Idle4 => idle4;
    public bool Shy5 => shy5;
    public bool Angry5 => angry5;
    public bool Happy5 => happy5;
    public bool Sad5 => sad5;
    public bool Idle5 => idle5;
}
