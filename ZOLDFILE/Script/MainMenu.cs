using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject settingsMenu;
    public Button startButton;
    public Button freeplayButton;
    public Button settingsButton;
    public Button exitButton;
    public Button quizModeButton; // Add a button for quiz mode

    // Add public fields for the scene names
    public string freeplaySceneName;
    public string quizModeSceneName;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
        SetButtonColors(startButton);
        SetButtonColors(freeplayButton);
        SetButtonColors(settingsButton);
        SetButtonColors(exitButton);
        SetButtonColors(quizModeButton); // Set colors for the quiz mode button
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
        // Load the Freeplay scene
        SceneManager.LoadScene(freeplaySceneName);
    }

    public void OnQuizModeButtonPressed()
    {
        // Load the Quiz Mode scene
        SceneManager.LoadScene(quizModeSceneName);
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