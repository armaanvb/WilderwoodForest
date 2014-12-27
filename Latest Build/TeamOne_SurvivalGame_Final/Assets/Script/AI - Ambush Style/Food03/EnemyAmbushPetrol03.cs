using UnityEngine;
using System.Collections;

public class EnemyAmbushPetrol03 : MonoBehaviour 
{
	// ENEMY WAYPOINT NODES TO FOLLOW
	public Transform Node01;
	public Transform Node02;
	public Transform Node03;
	public Transform Node04;

	// CURRENT TARGET OF THE ENEMY
	public Transform target;
	// TEMPORARY TARGET TO SAVE IT AFTER STOPPING TO CHASE PLAYER
	public Transform temp;
	// SPEED OF THE ENEMY
	public float speed;

	// Use this for initialization
	void Start () 
	{
		// WE SET THE STARTING TARGET
		target = Node01;
		// WE SET THE TEMPORARY TARGET TO CHANGE ACCORDING TO CURRENT TARGET
		temp = target;
	}

	void Update () 
	{
		// SPEED OF THE ENEMY
		float step = speed * Time.deltaTime;
		// ENEMY FACES THE WAY IT GOES
		transform.LookAt (target);
		// ENEMY STARTS GOING WHEREVER IS THE TARGET'S LOCATION
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		// AS LONG AS PLAYER DOESN'T GET THE FOOD TEMPORARY TARGET IS THE CURRENT TARGET
		if(GameObject.Find("Food03").GetComponent<FoodTrigger03>().playerEnter == false)
		{
			temp = target;
		}

		// IF PLAYER GETS THE FOOD, TEMPORARY TARGET SAVES AS THE LAST WAYPOINT TO GO AND ENEMY MOVES TOWARD PLAYER
		if(GameObject.Find("Food03").GetComponent<FoodTrigger03>().playerEnter == true)
		{
			target = GameObject.Find("Player").transform;
		}

		// IF PLAYER EXITS THE SPECIFIC AREA ENEMY STOPS FOLLOWING PLAYER AND GOES BACK TO LAST SAVED WAYPOINT
		if(GameObject.Find("Food03ExitTrigger").GetComponent<FoodExitTrigger03>().playerExit == true)
		{
			// FOOD TRIGGER TURNS FALSE SO PLAYER CAN RE-ENTER
			GameObject.Find("Food03").GetComponent<FoodTrigger03>().playerEnter = false;
			// PLAYER'S TARGET BECOMES THE LAST SAVED WAYPOINT
			target = temp;
			// EXIT TRIGGER TURNS FALSE SO PLAYER CAN RE-ENTER
			GameObject.Find("Food03ExitTrigger").GetComponent<FoodExitTrigger03>().playerExit = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// TARGETS THE NEXT WAYPOINT
		if(other.name == "Node01"){target = Node02;}
		if(other.name == "Node02"){target = Node03;}
		if(other.name == "Node03"){target = Node04;}
		if(other.name == "Node04"){target = Node01;}
	}
}
