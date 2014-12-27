using UnityEngine;
using System.Collections;

public class EnemyGuardStats : MonoBehaviour 
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
		node = GetComponent<EnemyAIGuard>().guardPoint;
		node.GetComponent<GuardRespawnNodes>().isHere = true;

		XPManager = GameObject.Find("Player").GetComponent<XPManager>();

		transform.localScale = new Vector3(0.3924384f, 0.3924384f, 0.3924384f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curHealth <= 0)
		{
			transform.FindChild("DeathEffect").gameObject.SetActive(true);
			GetComponent<EnemyAIGuard>().enabled = false;
			transform.FindChild("Grim").renderer.enabled = false;
			GetComponent<CapsuleCollider>().isTrigger = false;
			node.GetComponent<GuardRespawnNodes>().isHere = false;
			StartCoroutine("Delay");
			XPManager.receivedExperience = XPManager.GuardXPReward;
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

	IEnumerator Delay()
	{
		XPManager.receivedExperience = XPManager.GuardXPReward;
		return null;
	}
}
