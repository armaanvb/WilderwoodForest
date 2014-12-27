using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gunstate : State 
{
	public AudioClip arrowSound;
	private bool isSound = true;
	//variable of movement speed for the gun state
	public float moveSpeed = 5;
	//The variable for transform of the hero
	public Transform arrowSpawner;
	//variable of Gameobject for the bullet
	public GameObject arrow;
	public int arrowNumber;
	public float reloadTime;
	private bool canFire = true;

	public Text ammo;
	
	//Alows player to enter the current state
	public override void EnterState(PlayerController player)
	{
		base.EnterState(player);
		transform.FindChild("Crossbow").renderer.enabled = true;
	}
	
	public override void Update()
	{
		gameObject.GetComponent<meleestate>().durability.text = "";
		transform.FindChild("Sword").gameObject.SetActive(false);
		//The speed in which the character moves forward
		Vector3 movement = new Vector3(0, 0, Input.GetAxis("Vertical")) * moveSpeed;
		player.Move(movement);
	
		//Press fire button to instantiate the gameobject bullet according to the heros .position and .rotation
		if (Input.GetButtonDown ("Fire1") && canFire == true && arrowNumber > 0) 
		{
			if(isSound)
			{
				audio.clip = arrowSound;
				audio.Play();
				isSound = false;
			}
			StartCoroutine("FireDelay");
		}
			
		//Press e to change state into meleestate
		if (Input.GetKeyDown ("e"))
		{
			player.EnterState (player.meleestate);
		}

		ammo.text = "Arrow Left: " + arrowNumber;
	}
		
	IEnumerator FireDelay()
	{
		//Animation.Play("FireCrossbow");
		Instantiate (arrow, arrowSpawner.position, transform.rotation);
		arrowNumber -= 1;
		canFire = false;
		yield return new WaitForSeconds(reloadTime);
		canFire = true;
		isSound = true;
		StopCoroutine("FireDelay");
	}
	
	public override void ExitState()
	{
		transform.FindChild("Crossbow").renderer.enabled = false;
		base.ExitState();
	}
}

