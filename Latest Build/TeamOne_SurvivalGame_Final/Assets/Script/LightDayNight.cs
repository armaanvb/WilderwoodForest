using UnityEngine;
using System.Collections;

public class LightDayNight : MonoBehaviour 
{
	public ParticleSystem particle;

	void Update () 
	{
		if(GameObject.Find("Directional light").GetComponent<DayNight02>().timeDay >= 8 &&
		   		GameObject.Find("Directional light").GetComponent<DayNight02>().timeDay <= 17)
		{
			particle.enableEmission = false;
		}
		else
		{
			particle.enableEmission = true;
		}
	}
}
