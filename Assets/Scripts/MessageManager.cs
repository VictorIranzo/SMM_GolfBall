using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour {
    public Text HeaderText;
    public Text BodyText;
    public InputField nickField;

	// Use this for initialization
	void Start () {
        if (GameController.GameResult == -1) {
            HeaderText.text = "Game over";
            BodyText.text = "You lose! ";
        }
        else {
            HeaderText.text = "Congratulations";
            BodyText.text = "You win! ";
        }
        BodyText.text += "You get " + PlayerController.coinsCount + " coins and " + PlayerController.pointsCount + " points.\n";
        BodyText.text += CustomizedMessage(); 
	}

    private string CustomizedMessage()
    {
        int points = PlayerController.pointsCount;

        if (points < 100) return "You can feel bad. It is a very poor result.";
        if (points < 200) return "Not bad, but you can do it much better.";
        if (points < 500) return "Well done! You can improve it.";

        return "Amazing! You are one of the best players";
    }

    public void SaveScore()
    {
        // TODO: Store scores.

        MenuBack();
    }

    public void MenuBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
