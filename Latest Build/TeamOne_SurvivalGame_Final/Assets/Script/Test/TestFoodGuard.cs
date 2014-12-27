using UnityEngine;
using System.Collections;

public class TestFoodGuard : MonoBehaviour 
{
	float speed = 3;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Vector3.forward * Time.deltaTime * speed;
		StartCoroutine("Rotate");
	}

	IEnumerator Rotate()
	{
		float newRot = transform.position.y;
		newRot += Random.Range(0, 361);
		yield return new WaitForSeconds(1);
		StopCoroutine("Rotate");
	}
}
