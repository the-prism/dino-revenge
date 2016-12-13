using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Movement : MonoBehaviour
{

    public float speed = 6f;
    public GameObject cube;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;
    float TurnInputValue;
    float TurnSpeed = 180f;
    string TurnAxisName;
    GameObject t;
    bool canPlaceBomb = true;
	private float m_TurnInputValue; 
	private string m_TurnAxisName;
	public float m_TurnSpeed = 180f;


    void OnEnable()
    {
		m_TurnInputValue = 0f;
        playerRigidBody.isKinematic = false;
    }

    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        playerRigidBody.isKinematic = true;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
		m_TurnAxisName = "Horizontal2";
    }

    void Update()
    {
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);
        if ( Input.GetKey( "escape" ) )
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        if ( transform.position.y < -50 || transform.position.x > 500 || transform.position.z > 500 )
        {
            MainMenuController.player = 1;
            Application.LoadLevel( "Gameover" );
        }
        float horizontalAxis = 0;
        float verticalAxis = 0;

        if ( Input.GetKey( "j" ) )
        {
            anim.SetBool( "isWalk", true );
            horizontalAxis += 1;
        }
        else if ( Input.GetKeyUp( "j" ) )
        {
            anim.SetBool( "isWalk", false );
        }

        if ( Input.GetKey( "l" ) )
        {
            anim.SetBool( "isWalk", true );
            horizontalAxis += -1;
        }
        else if ( Input.GetKeyUp( "l" ) )
        {
            anim.SetBool( "isWalk", false );
        }

        if ( Input.GetKey( "k" ) )
        {
            anim.SetBool( "isWalk", true );
            verticalAxis += 1;
        }
        else if ( Input.GetKeyUp( "k" ) )
        {
            anim.SetBool( "isWalk", false );
        }

        if ( Input.GetKey( "i" ) )
        {
            anim.SetBool( "isWalk", true );
            verticalAxis += -1;
        }
        else if ( Input.GetKeyUp( "i" ) )
        {
            anim.SetBool( "isWalk", false );
        }

        if ( Input.GetKey( "u" ) )
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            if ( canPlaceBomb )
            {
                anim.SetBool( "attack", true );
                canPlaceBomb = false;
                t = ( GameObject ) Instantiate( cube, new Vector3( x, -0.5f, z ), transform.rotation );
            }
        }
        else if ( Input.GetKeyUp( "u" ) )
        {
            anim.SetBool( "attack", false );
        }

        if ( Input.GetKey( "o" ) )
        {
            canPlaceBomb = true;
        }
        else if ( Input.GetKeyUp( "o" ) )
        {
            anim.SetBool( "attack", false );
        }

        //TurnInputValue = Input.GetAxis (TurnAxisName);
        /*if (Input.GetKey ("space")) 
		{
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		}*/
        Move( horizontalAxis, verticalAxis );
        //Turn ();
        //Animating (h, v);
    }

    void FixedUpdate()
	{
		//Move (horizontalAxis,verticalAxis);
		Turn ();
	}

    void Move( float h, float v )
    {
        movement.Set( h, 0f, v );

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition( transform.position + movement );
    }

	private void Turn ()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
		
		// Make this into a rotation in the y axis.
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		
		// Apply this rotation to the rigidbody's rotation.
		playerRigidBody.MoveRotation (playerRigidBody.rotation * turnRotation);
	}

    void Animating( float h, float v )
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool( "IsWalking", walking );
    }
}
