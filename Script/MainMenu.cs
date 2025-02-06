using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPressed()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void OnFreeplayButtonPressed()
    {
        // Implement Freeplay button functionality here
    }

    public void OnSettingsButtonPressed()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
}