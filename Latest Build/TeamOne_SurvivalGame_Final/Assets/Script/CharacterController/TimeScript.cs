using UnityEngine;
using System.Collections;

public class TimeScript : MonoBehaviour 
{
	// CHANGE IN HIERARCHY TO GIVE A DIFFERENT SPEED
	public float countdown;
	public float countdownSpeed;

	// ONGUI STUFF NO NEED TO TOUCH
	public float barDisplay;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(20,60);
	public Texture2D fullTex;
	private Texture2D emptyTex = null;
	private float cd;
	
	void Start () 
	{
		// SOMETHING TO STABILIZE THE SPEED OF GUI AND COUNTDOWN ----- NO NEED TO TOUCH
		cd = countdown;
	}

	void Update () 
	{
		// COUNTDOWN AND COUNTDOWN SPEED ----- CHANGE IN HIERARCHY, NO NEED TO TOUCH HERE
		countdown -= Time.deltaTime * countdownSpeed;
		barDisplay = countdown / cd;
		// IF PLAYER DIES => ??? ----- CHANGE/ADD INSIDE THE BRACKET TO WHAT HAPPENS NEXT 
		if(countdown <= 0){countdown = 0;}
	}

	void OnGUI()
	{
		// NOTHING SHOULD CHANGE HERE. NO NEED TO TOUCH!
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

}
