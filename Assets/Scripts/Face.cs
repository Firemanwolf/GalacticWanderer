using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour
{
    [SerializeField] Image Character;

    [Header("Emotions")]
    [SerializeField] Sprite ShyFace, AngryFace,HappyFace, SadFace, IdleFace;
    [Header("Emotions2")]
    [SerializeField] Sprite ShyFace2, AngryFace2, HappyFace2, SadFace2, IdleFace2;
    [Header("Emotions3")]
    [SerializeField] Sprite ShyFace3, AngryFace3, HappyFace3, SadFace3, IdleFace3;
    [Header("Emotions4")]
    [SerializeField] Sprite ShyFace4, AngryFace4, HappyFace4, SadFace4, IdleFace4;
    [Header("Emotions5")]
    [SerializeField] Sprite ShyFace5, AngryFace5, HappyFace5, SadFace5, IdleFace5;
    public void FacialExpression(DialogueContent dialogueContent)
    {
        if (dialogueContent.Shy) { Character.sprite = ShyFace; return; }
        if (dialogueContent.Happy) { Character.sprite = HappyFace; return; }
        if (dialogueContent.Angry) { Character.sprite = AngryFace; return; }
        if (dialogueContent.Sad) { Character.sprite = SadFace; return; }

        if (dialogueContent.Shy2) { Character.sprite = ShyFace2; return; }
        if (dialogueContent.Happy2) { Character.sprite = HappyFace2; return; }
        if (dialogueContent.Angry2) { Character.sprite = AngryFace2; return; }
        if (dialogueContent.Sad2) { Character.sprite = SadFace2; return; }
        if (dialogueContent.Idle2) { Character.sprite = IdleFace2; return; }
        if (dialogueContent.Shy3) { Character.sprite = ShyFace3; return; }
        if (dialogueContent.Happy3) { Character.sprite = HappyFace3; return; }
        if (dialogueContent.Angry3) { Character.sprite = AngryFace3; return; }
        if (dialogueContent.Sad3) { Character.sprite = SadFace3; return; }
        if (dialogueContent.Idle3) { Character.sprite = IdleFace3; return; }
        if (dialogueContent.Shy4) { Character.sprite = ShyFace4; return; }
        if (dialogueContent.Happy4) { Character.sprite = HappyFace4; return; }
        if (dialogueContent.Angry4) { Character.sprite = AngryFace4; return; }
        if (dialogueContent.Sad4) { Character.sprite = SadFace4; return; }
        if (dialogueContent.Idle4) { Character.sprite = IdleFace4; return; }
        if (dialogueContent.Shy5) { Character.sprite = ShyFace5; return; }
        if (dialogueContent.Happy5) { Character.sprite = HappyFace5; return; }
        if (dialogueContent.Angry5) { Character.sprite = AngryFace5; return; }
        if (dialogueContent.Sad5) { Character.sprite = SadFace5; return; }
        if (dialogueContent.Idle5) { Character.sprite = IdleFace5; return; }
        Character.sprite = IdleFace; return;

        
       
    }

}
