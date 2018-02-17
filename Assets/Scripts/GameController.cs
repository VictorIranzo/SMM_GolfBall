using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // -1 -> Game Over
    // 0 -> Playing
    // 1 -> Win
    public static int GameResult { get; set; }

    public static int coinsCount { get; set; }
    public static int pointsCount { get; set; }


    void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameResult = 0;
        coinsCount = 0;
        pointsCount = 0;
    }

    public static void GoToNextLevel()
    {
        SceneManager.LoadScene("LevelResume");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
