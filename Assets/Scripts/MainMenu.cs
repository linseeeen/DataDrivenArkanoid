using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the first level
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //Quits the game application
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    //Loads the main menu
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
