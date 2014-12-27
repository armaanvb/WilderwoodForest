using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour 
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
			StartCoroutine("WaterBuff");
		}
	}

	IEnumerator WaterBuff()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().waterBuff += buffTime;
		renderer.enabled = false;
		collider.enabled = false;
		transform.FindChild("WaterParticle").GetComponent<ParticleSystem>().enableEmission = false;
		yield return new WaitForSeconds(10f);
		transform.parent.gameObject.GetComponent<ItemSpawner>().spawn = true;
		Destroy(gameObject);
		StopCoroutine("WaterBuff");
	}
}
