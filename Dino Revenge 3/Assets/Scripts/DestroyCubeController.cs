using UnityEngine;
using System.Collections;

public class DestroyCubeController : MonoBehaviour {
	public GameObject remains;
	void Update () 
	{
		if (Input.GetKey ("space")) 
		{
			GameObject t = (GameObject)Instantiate(remains, transform.position, transform.rotation);
			Destroy(gameObject);
			new WaitForSeconds(5);
			Destroy(t,1.0f);
		}
	}
}
