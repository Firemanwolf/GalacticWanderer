using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Transform character;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] TypeWriterEffect typeWriter;
    [SerializeField] private GameObject nextButton;
    public UnityAction EndAnimEvent;
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

    public void NextCharacter()
    {
        if(character.childCount!=0)
            Destroy(character.GetChild(0).gameObject);
        Instantiate(characters[charIndex].Ailment, character);
        
    }

    public bool IsLastCharacter()
    {
        return (charIndex >= characters.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
