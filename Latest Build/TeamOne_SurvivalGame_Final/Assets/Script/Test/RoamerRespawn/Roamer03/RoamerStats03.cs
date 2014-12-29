using UnityEngine;
using System.Collections;

public class RoamerStats03 : MonoBehaviour 
{
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthNormalized;

	public int swordDamage;
	public int arrowDamage;
	
	public int damage;
	public Transform node;

	public GameObject healthBar;

	XPManager XPManager;
	// Use this for initialization
	void Start () 
	{
		node = GetComponent<EnemyRoaming>().spawnPoint;
		node.GetComponent<Respawn03>().isHere = true;

		XPManager = GameObject.Find("Player").GetComponent<XPManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Transform nodeTarget = GetComponent<EnemyRoaming>().target;
		
		if (curHealth <= 0)
		{
			XPManager.receivedExperience = XPManager.RoamerXPReward;
			node.GetComponent<Respawn03>().isHere = false;
			Destroy (nodeTarget.gameObject);
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
			healthNormalized = (float)curHealth / (float)maxHealth;
			healthBar.transform.localScale = new Vector3(healthNormalized, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		}
		if(other.tag == "Arrow")
		{
			curHealth -= arrowDamage; 
			healthNormalized = (float)curHealth / (float)maxHealth;
			healthBar.transform.localScale = new Vector3(healthNormalized, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().curHealth -= damage;
	}
}
