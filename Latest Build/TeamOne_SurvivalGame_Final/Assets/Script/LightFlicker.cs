using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour 
{
	public Light _light;
	public float flickerSpeed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine ("flicker");
	}

	IEnumerator flicker()
	{
		float randomizer = Random.Range (0, 100);
		print (randomizer);
		if(randomizer >= 80 && randomizer <= 90)
		{
			_light.intensity += Time.deltaTime * 2;
		}
		
		if(randomizer > 20 && randomizer <= 30)
		{
			_light.intensity -= Time.deltaTime * 2;
		}

		if (_light.intensity >= 2 || _light.intensity <= 0.8f) 
		{
			_light.intensity = 1f;
		}

		yield return new WaitForSeconds(flickerSpeed);
		StopCoroutine("flicker");
	}
}
