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
    [SerializeField] private GameObject treatmentSystem;
    [SerializeField] private GameObject nextButton;

    [SerializeField] private DialogueObject intro;
    [SerializeField] private DialogueObject dayOver;

    private ResponseHandler responseHandler;
    private TypeWriterEffect typeWriterEffect;
    
    
    //clipboard stuff
    public static string currentClipboardInfo;
    
    public delegate void NextCharacterAction();
    public static event NextCharacterAction OnNextCharacter;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogue();
        //ShowDialogue(character.StartDialogue);
        ShowDialogue(intro);
        GameManager.Instance.EndAnimEvent += onNextEvent;
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
            //characterSprite.sprite = character.CharacterSprite[ind];
            DialogueContent dialogue = dialogueObject.Dialogue[i];
            yield return typeWriterEffect.Run(dialogue.DialogueText, textLabel);
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && typeWriterEffect.textfinished);
            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

        }

        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (dialogueObject.HasResponses)
        {
            speakerName.text = "You";
            textLabel.text = string.Empty;
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
            if (dialogueObject == intro|| dialogueObject==character.FinishDialogue)
            {
                NextCharacter();
            }
            else if (!treatmentSystem.activeSelf&& character!=null)
            {
                treatmentSystem.SetActive(true);
                nextButton.SetActive(true);
            }
            else
            {
                NextCharacter();
            }

        }

    }
    
    private void CloseDialogue() {

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }


    public void ShowFinalDialogue()
    {
        ShowDialogue(character.FinishDialogue);
        nextButton.SetActive(false);
    }
    public void NextCharacter()
    {
        treatmentSystem.SetActive(false);
        GameManager.Instance.charIndex++;
        if (!GameManager.Instance.IsLastCharacter()) 
        {
            character = GameManager.Instance.characters[GameManager.Instance.charIndex];
        }
        else 
        {
            CloseDialogue();
            nextButton.SetActive(false);
            GameManager.Instance.EndAnimEvent -= onNextEvent;
        }
        StartCoroutine(CharacterDisappear());
        nextButton.SetActive(false);
        if (OnNextCharacter != null)
            OnNextCharacter();
    }

    IEnumerator CharacterDisappear()
    {
        while (characterSprite.color.a > 0)
        {
            Color newColor = characterSprite.color;
            newColor.a -= Time.deltaTime;
            characterSprite.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        
        if (GameManager.Instance.charIndex <= 1)
            GameManager.Instance.NextCharacter();
        GameManager.Instance.EndAnimEvent();
    }

    private void onNextEvent()
    {
        if (GameManager.Instance.charIndex <= 1)
        {
            characterSprite.sprite = character.CharacterSprite[0];
            characterSprite.color = Color.white;
            ShowDialogue(character.StartDialogue);
        }
        else
        {
            ShowDialogue(dayOver);
        }

    }
}
