using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private DialogueObject startDialogue;
    [SerializeField] private DialogueObject finishDialogue;
    [SerializeField] private string characterName;
    [SerializeField] private Sprite[] characterSprite;
    [SerializeField] private int symptoms;
    [SerializeField] private GameObject ailment;
    
    [SerializeField] private Sprite face;
    [SerializeField] private string race;
    public DialogueObject StartDialogue => startDialogue;
    public DialogueObject FinishDialogue => finishDialogue;
    public string CharacterName => characterName;

    public Sprite[] CharacterSprite => characterSprite;

    public GameObject Ailment => ailment;

    public Sprite Face => face;
    public string Race => race;


}
