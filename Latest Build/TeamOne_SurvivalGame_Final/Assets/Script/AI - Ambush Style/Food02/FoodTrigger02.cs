using UnityEngine;
using System.Collections;

public class FoodTrigger02 : MonoBehaviour 
{
	public bool playerEnter = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player"){playerEnter = true;}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.name == "Player")
		{
			GameObject.Find("Player").GetComponent<PlayerStats>().curFood += 
				Time.deltaTime * GameObject.Find("Player").GetComponent<PlayerStats>().speedFood * 10f;
		}
	}
}
