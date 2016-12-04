using UnityEngine;
using System.Collections;

public class DestroyCubeController : MonoBehaviour {
	public GameObject remains;
	void Update () 
	{
		if (Input.GetKey ("space")) 
		{
			Instantiate(remains, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
