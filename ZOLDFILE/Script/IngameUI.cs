using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button mainMenuButton;

    void Start()
    {
        pausePanel.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main menu UI");
    }
}