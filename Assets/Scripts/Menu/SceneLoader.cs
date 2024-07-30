using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject prevScene;
    [SerializeField] GameObject optionPanel;

    private void Update()
    {
        PrevLoader();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (optionPanel.activeSelf) // Check if the option panel is active
        {
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Time.timeScale = 1; // Resume the game
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void GoToMenu()
    { 
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;
        SceneManager.LoadScene(previousSceneIndex);
    }
    public void PrevLoader()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "First_Level")
        {
            prevScene.gameObject.SetActive(false);
        }
    }
}
