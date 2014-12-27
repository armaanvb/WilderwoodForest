using UnityEngine;
using System.Collections;

public class QuitTutorial : MonoBehaviour 
{
	public Font myFont;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F1)){Application.LoadLevel("MainMenu");}
	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		GUI.Label(new Rect (170, 10, 200, 300), "Press 'F1' to Leave Tutorial Anytime");
	}
}
