using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Transform character;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] TypeWriterEffect typeWriter;
    [SerializeField] private GameObject nextButton;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public Character[] characters;
    public int charIndex = 0;

    public void CheckIfCured(Character nextCharacter) 
    {
        bool isCured =  character.childCount == 0;
        if (!isCured)
        {
            for (int i = 0; i < character.childCount; i++)
            {
                Destroy(character.GetChild(i).gameObject);
            }
            StartCoroutine(AnnouncingResult("You've failed to cure this patient"));
        }
        else StartCoroutine(AnnouncingResult("You've successfully cured this patient"));
        Instantiate(nextCharacter.Ailment, character);
        
    }

    public bool IsLastCharacter()
    {
        return (charIndex >= characters.Length);
    }

    IEnumerator AnnouncingResult(string sentenceToType)
    {
        resultPanel.SetActive(true);
        yield return typeWriter.Run(sentenceToType, resultPanel.GetComponentInChildren<TextMeshProUGUI>());
        yield return new WaitForSeconds(3f);
        resultPanel.SetActive(false);
    }
}
