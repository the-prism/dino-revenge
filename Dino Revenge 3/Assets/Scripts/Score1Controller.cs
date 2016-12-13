using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score1Controller : MonoBehaviour {
	UnityEngine.UI.Text Player1_score;
	// Use this for initialization
	void Start () {
		Player1_score = GetComponent<Text> ();
		Player1_score.text = "Score : " + MainMenuController.score1;
	}
}
