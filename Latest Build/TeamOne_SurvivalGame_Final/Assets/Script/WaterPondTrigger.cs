using UnityEngine;
using System.Collections;

public class WaterPondTrigger : MonoBehaviour 
{
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			GameObject.Find("Player").GetComponent<PlayerStats>().curHydration +=
				Time.deltaTime * GameObject.Find("Player").GetComponent<PlayerStats>().speedHydration * 2;
		}
	}
}
