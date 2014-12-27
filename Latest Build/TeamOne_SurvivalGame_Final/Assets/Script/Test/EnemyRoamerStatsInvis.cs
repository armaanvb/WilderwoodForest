using UnityEngine;
using System.Collections;

public class EnemyRoamerStats : MonoBehaviour 
{
	public int maxHealth = 100;
	public int curHealth = 100;

	public int damage;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curHealth <= 0)
		{
			Destroy (gameObject, 1.0f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().curHealth -= damage;

		if(other.tag == "Sword")
		{
			curHealth -= 10;
			print ("Enemy Roamer Invis = " + curHealth);
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().curHealth -= damage;
	}
}
