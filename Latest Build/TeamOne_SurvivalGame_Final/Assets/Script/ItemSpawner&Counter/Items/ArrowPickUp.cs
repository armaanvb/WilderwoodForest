using UnityEngine;
using System.Collections;

public class ArrowPickUp : MonoBehaviour {

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
		GameObject.Find("Player").GetComponent<gunstate>().arrowNumber += 5;
		renderer.enabled = false;
		collider.enabled = false;
		transform.FindChild("ArrowParticle").GetComponent<ParticleSystem>().enableEmission = false;
		yield return new WaitForSeconds(10f);
		transform.parent.gameObject.GetComponent<ItemSpawner>().spawn = true;
		Destroy(gameObject);
		StopCoroutine("Delay");
	}
}
