using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour {
	//Variable for bullet gameobject
	public GameObject bullet;
	//Variable for the transform of the gun
	public Transform gun;
	//variable for the monster gameobject
	public GameObject monster;
	//Duration of the ammo
	public float lifetime;

	void Start () {

		}
	// Update is called once per frame
	void Update () {
		//Adds force to the bullet
		bullet.rigidbody.AddForce (gun.forward * 1000); 
		//Find's the ammo clones and destroys them after the duration timer
		if (gameObject.name == "ammo(Clone)") {
						Destroy (gameObject, lifetime);
				}
	}

	// Upon collision the bullet does damage and subtracts it from the enemyhealth script
	void OnCollisionEnter(Collision collision)
	{
		float distance = Vector3.Distance (monster.transform.position, transform.position);
		
		if (distance < 2) {
		if (bullet) {
						enemyhealth eh = (enemyhealth)monster.GetComponent ("enemyhealth");
						eh.adjustCurHealth (-5);
				}
	}
		 
}
}