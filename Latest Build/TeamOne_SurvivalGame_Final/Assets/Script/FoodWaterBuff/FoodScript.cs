using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour 
{
	public float buffTime;
	private float temp;
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
			StartCoroutine("FoodBuff");
		}
	}

	IEnumerator FoodBuff()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().foodBuff += buffTime;
		renderer.enabled = false;
		collider.enabled = false;
		transform.FindChild("FoodParticle").GetComponent<ParticleSystem>().enableEmission = false;
		yield return new WaitForSeconds(10f);
		transform.parent.gameObject.GetComponent<ItemSpawner>().spawn = true;
		Destroy(gameObject);
		StopCoroutine("FoodBuff");
	}
}
