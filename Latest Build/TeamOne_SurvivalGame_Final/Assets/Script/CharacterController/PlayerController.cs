using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {


	//Used gameObject to determine the point in which the hero spawns
	//public 	GameObject	 spawnPoint;
	//The hero gameobject
	public 	GameObject   hero;
	//Variable that determines the speed/direction in which the hero runs
	public 	float		 movementSpeed              = 10f; 
	public string		 xMovementInputName 		= "Horizontal";
	public string 		 zMovementInputName 		= "Vertical";
	private CharacterController controller 			= null;
	//Variable for velocity
	private Vector3      velocity 				    = Vector3.zero;


	// Current stat to determine which state the hero is currently in
	public State currentState;

	[HideInInspector]
	public gunstate gunstate;
	[HideInInspector]
	public meleestate meleestate;
	

	private void Reset()
	{

		//Pulls the gunstate from assets
		if(gunstate == null)
		{
			this.gameObject.AddComponent<gunstate>();
			gunstate = this.GetComponent<gunstate>();
		}
		//Pulls the meleestate from assets
		if(meleestate == null)
		{
			this.gameObject.AddComponent<meleestate>();
			meleestate = this.GetComponent<meleestate>();
		}
	}


	void Start () 
	{
		rigidbody.freezeRotation = false;
		controller = GetComponent<CharacterController> ();

		gunstate.enabled = false;
		meleestate.enabled = false;

		EnterState(gunstate);
	}
	

	void Update () 
	{
		//Character movements determined by the variable velocity
		velocity.x = 0;
		velocity.z = 0;

		velocity += transform.right * Input.GetAxis (xMovementInputName) * movementSpeed;
		velocity += transform.forward * Input.GetAxis (zMovementInputName) * movementSpeed;
		velocity += Physics.gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		Animator animator = transform.FindChild("RiggedPlayer").GetComponent<Animator>();
		animator.GetBool("isIdle");
		
		if(velocity.x != 0 || velocity.z != 0){animator.SetBool("isIdle", false);}
		if(velocity.x == 0 && velocity.z == 0){animator.SetBool("isIdle", true);}
	}
	

	//The function in allows the system to enter different types of states(gunstate or melee state)
	public void EnterState(State newState)
	{
		if(currentState != null)
			currentState.ExitState();
		
		currentState = newState;
	
		
		if(currentState != null)
			currentState.EnterState(this);
		

	}
	//Function that adds foce into the rigid body for acceleration
	public void Move(Vector3 movement)
	{
		rigidbody.AddRelativeForce (movement, ForceMode.Acceleration);
	}

}
