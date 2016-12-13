using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverController : MonoBehaviour {
	UnityEngine.UI.Text gameoverText;
	// Use this for initialization
	void Start () 
	{
		gameoverText = GetComponent<Text> ();
		gameoverText.text = "Player " + MainMenuController.player + " won !";
		if (MainMenuController.player == 1) {
			MainMenuController.score1 = MainMenuController.score1 + 1;
		} else {
			MainMenuController.score2 = MainMenuController.score2 + 1;
		}
	}
}
