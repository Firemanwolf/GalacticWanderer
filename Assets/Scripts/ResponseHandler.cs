using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;


    List<GameObject> tempResponseButton = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
        //lvLoader = lvmanager.GetComponent<LevelLoader>();
        
    }
    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponentInChildren<TextMeshProUGUI>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));
            tempResponseButton.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }
        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);

        responseBox.gameObject.SetActive(true);
    }
private void OnPickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButton)
        {
            Destroy(button);
        }

        tempResponseButton.Clear();
        if (response.transition)
        {
            //lvLoader.LoadNextLevel();
            return;
        }
        dialogueUI.ShowDialogue(response.DialogueObject);
    }
}
