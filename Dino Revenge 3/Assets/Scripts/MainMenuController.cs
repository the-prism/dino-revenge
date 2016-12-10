using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	static public int player;
	public void exit()
	{
		// Exit game when played in the editor
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}

	public void play() 
	{
		Application.LoadLevel("MiniGame");
	}
}
