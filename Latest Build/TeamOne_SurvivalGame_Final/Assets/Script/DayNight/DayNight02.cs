using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayNight02 : MonoBehaviour
{

	public AudioClip dayMusic;
	public AudioClip nightMusic;

	public int dayCounter;
	public Light _light;
	public float timeDay;
	public float speed;
	public float fixedTime;
	public float fixedTimeSpeed;

	public Color fogNight;
	public Color fogDay;

	public Text timeGUI;

	public bool isFog;
	private bool isDay = true;

	// Update is called once per frame
	void Update () 
	{
		fixedTime += Time.deltaTime * fixedTimeSpeed;
		timeDay += Time.deltaTime * fixedTimeSpeed;
		if(fixedTime >= 24){fixedTime = 1;}
		if(timeDay >= 24){timeDay = 1; dayCounter++;}

		if(timeDay >= 1 && timeDay <= 8)
		{
			_light.intensity = 0;
		}

		if(timeDay >= 8  && timeDay <= 17)
		{
			if(isDay == true)
			{
				audio.clip = dayMusic;
				audio.Play ();
				isDay = false;
			}
			_light.intensity += Time.deltaTime * speed;
			RenderSettings.fogDensity = 0.025f;
			RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, fogDay, Time.deltaTime*0.1f);
		}

		if(timeDay >= 17  && timeDay <= 24)
		{
			if(isDay == false)
			{
				audio.clip = nightMusic;
				audio.Play ();
				isDay = true;
			}
			_light.intensity += Time.deltaTime * (-speed) * 2f;
			RenderSettings.fogDensity = 0.055f;
			RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, fogNight, Time.deltaTime*0.1f);
		}

		if(isFog == true){RenderSettings.fog = true;}
		if(isFog != true){RenderSettings.fog = false;}

		timeGUI.text = timeDay.ToString("0.00");
	}
}
