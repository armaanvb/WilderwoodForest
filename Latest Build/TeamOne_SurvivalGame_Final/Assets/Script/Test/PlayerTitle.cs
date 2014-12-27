using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTitle : MonoBehaviour 
{
	public Text title;

	private GameObject dayNight;
	private DayNight02 dayNightScript;
	// Use this for initialization
	void Start () 
	{
		dayNightScript = GameObject.Find("Directional light").GetComponent<DayNight02>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(dayNightScript.dayCounter == 0)
		{
			title.text = "Loner";
		}

		if(dayNightScript.dayCounter == 1)
		{
			title.text = "Survivor";
		}

		if(dayNightScript.dayCounter == 2)
		{
			title.text = "The Hunter";
		}

		if(dayNightScript.dayCounter == 3)
		{
			title.text = "The Wild";
		}

		if(dayNightScript.dayCounter == 4)
		{
			title.text = "Ghostbuster";
		}

		if(dayNightScript.dayCounter == 5)
		{
			title.text = "Bear Grylls";
		}
	}
}
