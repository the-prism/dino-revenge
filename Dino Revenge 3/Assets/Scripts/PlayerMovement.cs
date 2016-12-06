using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	public GameObject cube;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;
	float TurnInputValue;
	float TurnSpeed = 180f;
	string TurnAxisName;
	GameObject t;


	void OnEnable()
	{
		//TurnInputValue = 0f;
		//playerRigidBody.isKinematic = false;
	}

	private void OnDisable ()
	{
		// When the tank is turned off, set it to kinematic so it stops moving.
		//playerRigidBody.isKinematic = true;
	}

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void Start()
	{
		TurnAxisName = "Horizontal";
	}

	void Update()
	{
		float horizontalAxis = 0;
		float verticalAxis = 0;
		if (Input.GetKey ("right")) 
		{
			horizontalAxis += 1;
		}
		if (Input.GetKey ("left")) 
		{
			horizontalAxis += -1;
		}
		if (Input.GetKey ("up")) 
		{
			verticalAxis += 1;
		}
		if (Input.GetKey ("down")) 
		{
			verticalAxis += -1;
		}
		if (Input.GetKey ("k")) 
		{
			float x = transform.position.x;
			float y = transform.position.y;
			float z = transform.position.z;
			t = (GameObject)Instantiate(cube,new Vector3(x,-0.5f,z), transform.rotation);
		}

		//TurnInputValue = Input.GetAxis (TurnAxisName);
		/*if (Input.GetKey ("space")) 
		{
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		}*/
		Move (horizontalAxis, verticalAxis);
		//Turning ();
		//Animating (h, v);
	}

	/*void FixedUpdate()
	{
		Move (horizontalAxis,verticalAxis);
		//Turning ();
	}*/

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);
	}

	/*void Turning()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = TurnInputValue * TurnSpeed * Time.deltaTime;
		
		// Make this into a rotation in the y axis.
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		
		// Apply this rotation to the rigidbody's rotation.
		playerRigidBody.MoveRotation (playerRigidBody.rotation * turnRotation);
	}*/

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
