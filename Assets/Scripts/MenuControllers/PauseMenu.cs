using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.P))
        // {
        //     if(isPaused)
        //     {
        //         ResumeGame();
        //     }

        //     else
        //     {
        //         PauseGame();
        //     }
        // }   
    }



    public void ResumeGame()
    {
        // Disable the pause screen ui element in canvas
        pauseMenuUI.SetActive(false);

        // Unreeze time in game
        Time.timeScale = 1f;

        // Change isPause variable to false
        isPaused = true;

    }

    public void PauseGame()
    {
        // Enable the pause screen ui element in canvas
        pauseMenuUI.SetActive(true);

        // Freeze time in game
        Time.timeScale = 0f;

        // Change isPause variable to true
        isPaused = true;
    }


    // SAVE FUNCTION
    public void SaveGame()
    {
        Debug.Log("game saved");
    }
    
    // LOAD FUNCTION
    public void LoadGame()
    {
        Debug.Log("loaded succesfully");

    }

    // Go to MENU FUNCTION
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("here comes the main menu");
    }

    // QUIT FUNCTION
    public void QuitGame()
    {
        Debug.Log("i QUIT");
        Application.Quit();

    }

}
