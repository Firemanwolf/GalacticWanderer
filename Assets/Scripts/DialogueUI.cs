using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI textLabel;
    [SerializeField] private DialogueObject Dialogue;
    [SerializeField] private GameObject Character;
    

    private ResponseHandler responseHandler;
    private TypeWriterEffect typeWriterEffect;
    
    
    //clipboard stuff
    public delegate void LearnInfoAction(string info);
    public static event LearnInfoAction OnLearnInfo;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogue();
        ShowDialogue(Dialogue);
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

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
        }

    }
    
    private void CloseDialogue() {

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
