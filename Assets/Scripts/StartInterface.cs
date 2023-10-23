using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartInterface : MonoBehaviour
{

    Button thisbutton;
  [SerializeField]  GameObject CreditPanel;

    private void Awake()
    {
        thisbutton = GetComponent<Button>();
    }

    private void Start()
    {
        switch (transform.name)
        {
            case "StartButton":
                thisbutton.onClick.AddListener(StartButtonClicked);
                break;
            case "EndButton":
                thisbutton.onClick.AddListener(EndButtonClicked);
                break;
            case "CreditsButton":
                thisbutton.onClick.AddListener(CreditsButtonClicked);
                break;
            case "QuitButton":
                thisbutton.onClick.AddListener(QuitButtonClicked);
                break;
        }
    }

    void StartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void EndButtonClicked() {
        SceneManager.LoadScene("StartScene");
    }
    void CreditsButtonClicked()
    {
        CreditPanel.SetActive(true);
    }

    void QuitButtonClicked()
    {
        Application.Quit();
    }
}
