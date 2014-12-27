using UnityEngine;
using System.Collections;

public class SwordPickUp : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			StartCoroutine("Delay");
		}
	}

	IEnumerator Delay()
	{
		GameObject.Find("Player").GetComponent<meleestate>().hasSword = true;
		GameObject.Find("Player").GetComponent<meleestate>().transform.FindChild("Sword").gameObject.SetActive(true);
		GameObject.Find("Sword").GetComponent<ItemDurability>().itemDurability = 15;
		renderer.enabled = false;
		collider.enabled = false;
		yield return new WaitForSeconds(10f);
		transform.parent.gameObject.GetComponent<ItemSpawner>().spawn = true;
		Destroy(gameObject);
		StopCoroutine("Delay");
	}
}
