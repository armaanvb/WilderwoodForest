using UnityEngine;
using System.Collections;

public class PlayerFlashLight : MonoBehaviour 
{
	private bool on = false;
	private bool isSound;
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(isSound){audio.Play(); isSound = false;}
			on = !on;
		}
		if(on)
		{

			isSound = true;
			light.enabled = true;
			transform.FindChild("FlashlightTrigger").GetComponent<BoxCollider>().enabled = true;
		}
		else if(!on)
		{
			isSound = true;
			light.enabled = false;
			transform.FindChild("FlashlightTrigger").GetComponent<BoxCollider>().enabled = false;
		}
	}
}
