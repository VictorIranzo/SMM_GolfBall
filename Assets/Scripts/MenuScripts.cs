using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour {

    public void LoadGame() {
        SceneManager.LoadScene("MiniGame");
    }

    public void GoToScores()
    {
        SceneManager.LoadScene("Scores");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
