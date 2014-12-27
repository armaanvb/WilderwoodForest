using UnityEngine;
using System.Collections;

public class EnemyFoodGuardStats02 : MonoBehaviour 
{
	public int maxHealth = 100;
	public int curHealth = 100;

	public int swordDamage;
	public int arrowDamage;
	
	public float damage;
	public Transform node;

	XPManager XPManager;
	// Use this for initialization
	void Start () 
	{
		node = GetComponent<EnemyAmbushPetrol>().spawnPoint;
		node.GetComponent<FoodEnemy03Respawn>().isHere = true;

		XPManager = GameObject.Find("Player").GetComponent<XPManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curHealth <= 0)
		{
			XPManager.receivedExperience = XPManager.FoodGuardXPReward;
			node.GetComponent<FoodEnemy03Respawn>().isHere = false;
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().curHealth -= damage;
		
		if(other.tag == "Sword")
		{
			GameObject.Find("Player").GetComponent<meleestate>().transform.FindChild("Sword").GetComponent<ItemDurability>().itemDurability -= 1;
			curHealth -= swordDamage;
		}
		if(other.tag == "Arrow"){curHealth -= arrowDamage;}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().curHealth -= damage;
	}
}

