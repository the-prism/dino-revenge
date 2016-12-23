using UnityEngine;
using System.Collections;

public class DestroyCubeController : MonoBehaviour {
	public GameObject remains;
	public float playerId;
	void Update () 
	{
		if ( (playerId == 1 && Input.GetKey ("e")) || (playerId == 2 && Input.GetKey ("o")) )
		{
			GameObject t = (GameObject)Instantiate (remains, transform.position, transform.rotation);
			Destroy (gameObject);
			new WaitForSeconds (10);
			Destroy (t, 1.0f);
		}
	}
}
