using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	static public int player;
	static public int score1 = 0;
	static public int score2 = 0;
	public void exit()
	{
		// Exit game when played in the editor
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}

	public void play() 
	{
		Application.LoadLevel("MiniGame");
	}
}
