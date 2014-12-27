using UnityEngine;
using System.Collections;

public class SignScript : MonoBehaviour 
{
	public string firstRow;
	public string secondRow;
	public string thirdRow;

	public int x;
	public int y1;
	public int y2;
	public int y3;

	public Font myFont;

	public bool showGUI = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
		{
			showGUI = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "Player")
		{
			showGUI = false;
		}
	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		if(showGUI)
		{
			GUI.Label(new Rect (x, 300 + y1, 200, 300), firstRow);
			GUI.Label(new Rect (x, 300 + y2, 200, 300), secondRow);
			GUI.Label(new Rect (x, 300 + y3, 200, 300), thirdRow);
		}
	}
}
