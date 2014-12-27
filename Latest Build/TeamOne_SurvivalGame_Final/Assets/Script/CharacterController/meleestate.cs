using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class meleestate : State
{
	public AudioClip swordSound;
	private bool isSound = true;
	//Variable in which the hero moves in melee state
	public float moveSpeed = 5;
	//Variable for the melee weapon
	public GameObject sword;
	public bool hasSword = false;

	public Text durability;
	
	public void Start ()
	{

	}

	//Function of entering the current state
	public override void EnterState(PlayerController player)
	{
		base.EnterState(player);
		transform.FindChild("Main Camera").transform.FindChild("crosshair").gameObject.SetActive(false);
		if(hasSword == true)
		{
			transform.FindChild("Sword").gameObject.SetActive(true);
			transform.FindChild("Sword").renderer.enabled = true;
		}
		else
			transform.FindChild("Sword").gameObject.SetActive(false);
	}
	
	public override void Update()
	{
		gameObject.GetComponent<gunstate>().ammo.text = "";
		//Player movement in according the the variable set up
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;
		player.Move(movement);

		//fire to attack with the sword, and to turn on the renderer for sword on for a breif moment
		if (Input.GetButtonDown ("Fire1")) 
		{
			Attack ();
		} 

		//Press e to change states back into gun state
		if (Input.GetKeyDown ("e"))
		{
			player.EnterState (player.gunstate);
		}

		durability.text = "Sword Durability: " + transform.FindChild("Sword").GetComponent<ItemDurability>().itemDurability;
	}
	// function for attacking
	private void Attack() 
	{
		if(isSound)
		{
			audio.clip = swordSound;
			audio.Play();
			isSound = false;
		}
		StartCoroutine("slashDelay");
	}

	IEnumerator slashDelay()
	{
		//Animation.Play("SlashSword");
		transform.FindChild("Sword").GetComponent<MeshCollider>().enabled = true;
		yield return new WaitForSeconds(0.5f);
		transform.FindChild("Sword").GetComponent<MeshCollider>().enabled = false;
		isSound = true;
		StopCoroutine("slashDelay");
	}

	public override void ExitState()
	{
		transform.FindChild("Sword").renderer.enabled = false;
		transform.FindChild("Main Camera").transform.FindChild("crosshair").gameObject.SetActive(true);
		base.ExitState();
	}


}
