using UnityEngine;
using System.Collections;

public class enemybullet : MonoBehaviour {

	public GameObject bullet;
	public Transform monster;
	public GameObject hero;
	public float lifetime;
	
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		bullet.rigidbody.AddForce (monster.forward * 100); 


			if(gameObject.name == "enemybullet(Clone)"){
				Destroy(gameObject, lifetime);
			}

	}
	
	void OnCollisionEnter(Collision collision)
	{
		float distance = Vector3.Distance (hero.transform.position, transform.position);
		
		if (distance < 2) {
			if (bullet) {
				PlayerStats ph = (PlayerStats)hero.GetComponent ("PlayerStats");
				ph.adjustCurHealth (-5);
			}
		}
		 
	}
}