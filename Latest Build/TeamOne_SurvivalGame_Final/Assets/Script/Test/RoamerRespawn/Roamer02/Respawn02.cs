using UnityEngine;
using System.Collections;

public class Respawn02 : MonoBehaviour 
{
	public GameObject guardSpawn;
	public bool isHere = true;
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find("Directional light").GetComponent<DayNight02>().timeDay >= 1 && 
		    GameObject.Find("Directional light").GetComponent<DayNight02>().timeDay <= 1.10f && isHere == false)
		{
			StartCoroutine("Delay");
		}
	}
	
	IEnumerator Delay()
	{
		GameObject enemy = Instantiate(guardSpawn, transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = transform.parent;
		yield return new WaitForSeconds(1);
		StopCoroutine("Delay");
	}
}
