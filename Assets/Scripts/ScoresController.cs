using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresController : MonoBehaviour {

    public Text scoresText;

	// Use this for initialization
	void Start () {
        scoresText.text = DataController.GetScores();
	}

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
	
}
