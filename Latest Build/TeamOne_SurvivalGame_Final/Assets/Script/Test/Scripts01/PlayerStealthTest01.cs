using UnityEngine;
using System.Collections;

public class PlayerStealthTest01 : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			InStealth ();
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			OutStealth ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "HideLoc")
		{
			InStealth();
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.name == "HideLoc")
		{
			InStealth();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "HideLoc")
		{
			OutStealth();
		}
	}


	void InStealth()
	{
		GameObject[] enemy;
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject distance in enemy) 
		{
			distance.transform.GetComponent<EnemyAIGuard>().followDist = 0.5f;
		}
	}

	void OutStealth()
	{
		GameObject[] enemy;
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject distance in enemy) 
		{
			distance.transform.GetComponent<EnemyAIGuard>().followDist = 
				distance.transform.GetComponent<EnemyAIGuard>().tempfollowDist;
		}
	}
}
