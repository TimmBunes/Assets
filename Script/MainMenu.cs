using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject settingsMenu;
    public Button startButton;
    public Button freeplayButton;
    public Button settingsButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
        SetButtonColors(startButton);
        SetButtonColors(freeplayButton);
        SetButtonColors(settingsButton);
        SetButtonColors(exitButton);
    }

    void SetButtonColors(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.gray;
        cb.pressedColor = Color.green;
        cb.selectedColor = Color.blue;
        button.colors = cb;
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