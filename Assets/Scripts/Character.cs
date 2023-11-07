using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private DialogueObject startDialogue;
    [SerializeField] private string characterName;
    [SerializeField] private Sprite[] characterSprite;
    [SerializeField] private int symptoms;
    [SerializeField] private GameObject ailment;
    
    public DialogueObject StartDialogue => startDialogue;
    public string CharacterName => characterName;

    public Sprite[] CharacterSprite => characterSprite;

    public GameObject Ailment => ailment;


}
