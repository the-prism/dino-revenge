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
	}
}
