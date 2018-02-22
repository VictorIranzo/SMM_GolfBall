using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresController : MonoBehaviour {

    public Text goldenUser;
    public Text silverUser;
    public Text bronzeUser;

    public Text goldenPoints;
    public Text silverPoints;
    public Text bronzePoints;

	// Use this for initialization
	void Start () {
         goldenUser.text = "";
         silverUser.text = "";
         bronzeUser.text = "";

         goldenPoints.text = "";
         silverPoints.text = "";
         bronzePoints.text = "";

        List<Score> bestScores = DataController.GetScores();

        if (bestScores.Count > 0)
        {
            Score gold = bestScores.ElementAt(0);
            goldenUser.text = gold.playerNick;
            goldenPoints.text = gold.points.ToString();
        }
        if (bestScores.Count > 1)
        {
            Score silver = bestScores.ElementAt(1);
            silverUser.text = silver.playerNick;
            silverPoints.text = silver.points.ToString();

        }
        if (bestScores.Count > 2)
        {
            Score bronze = bestScores.ElementAt(1);
            bronzeUser.text = bronze.playerNick;
            bronzePoints.text = bronze.points.ToString();
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
	
}
