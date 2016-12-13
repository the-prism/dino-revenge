using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score2Controller : MonoBehaviour {
	UnityEngine.UI.Text Player2_score;
	// Use this for initialization
	void Start () {
		Player2_score = GetComponent<Text> ();
		Player2_score.text = "Score : " + MainMenuController.score2;
	}
}
