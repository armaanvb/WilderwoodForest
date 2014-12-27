using UnityEngine;
using System.Collections;

public class FoodExitTrigger02 : MonoBehaviour 
{
	public bool playerExit = false;
	
	void OnTriggerExit(Collider other)
	{
		if(other.name == "Player"){playerExit = true;}
	}

	/*void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player"){playerExit = false;;}
	}*/
}
