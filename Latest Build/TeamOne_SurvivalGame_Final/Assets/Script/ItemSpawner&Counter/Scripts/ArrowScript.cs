using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour 
{
	public float arrowSpeed;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Destroy");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "EnemyGuard"){Destroy (gameObject);}
		if(other.tag == "EnemyRoam"){Destroy (gameObject);}
		if(other.tag == "Enemy"){Destroy (gameObject);}
	}
}
