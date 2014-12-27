using UnityEngine;
using System.Collections;

public class FoodExitTrigger03 : MonoBehaviour 
{
	public bool playerExit = false;
	
	void OnTriggerExit(Collider other)
	{
		if(other.name == "Player"){playerExit = true;}
	}
}
