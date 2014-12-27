using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour 
{
	public bool isFog;

	void Update () 
	{
		if(isFog == true){RenderSettings.fog = true;}
		if(isFog != true){RenderSettings.fog = false;}
	}
}
