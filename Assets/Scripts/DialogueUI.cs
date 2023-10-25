using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI textLabel;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Character character;
    [SerializeField] private Image characterSprite;
    

    private ResponseHandler responseHandler;
    private TypeWriterEffect typeWriterEffect;
    
    
    //clipboard stuff
    public delegate void LearnInfoAction(string info);
    public static event LearnInfoAction OnLearnInfo;
    
    public delegate void NextCharacterAction();
    public static event NextCharacterAction OnNextCharacter;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogue();
        ShowDialogue(character.StartDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            speakerName.text = dialogueObject.Dialogue[i].Speaker;
            int ind = dialogueObject.Dialogue[i].SpriteIndex;
            characterSprite.sprite = character.CharacterSprite[ind];
            DialogueContent dialogue = dialogueObject.Dialogue[i];
            //face.FacialExpression(dialogue);
            yield return typeWriterEffect.Run(dialogue.DialogueText, textLabel);
            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
            yield return new WaitForSeconds(0.2f);
            if (!string.IsNullOrWhiteSpace(dialogue.ClipBoardInfo))
            {
                if (OnLearnInfo != null)
                {
                    OnLearnInfo(dialogue.ClipBoardInfo);
                }
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && typeWriterEffect.textfinished);

        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (dialogueObject.HasResponses)
        {
            speakerName.text = "You";
            textLabel.text = string.Empty;
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
            NextCharacter();
        }

    }
    
    private void CloseDialogue() {

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        
    }

    public void NextCharacter()
    {
        GameManager.Instance.charIndex++;
        character = GameManager.Instance.characters[GameManager.Instance.charIndex];
        ShowDialogue(character.StartDialogue);
        if (OnNextCharacter != null)
            OnNextCharacter();
    }
}
