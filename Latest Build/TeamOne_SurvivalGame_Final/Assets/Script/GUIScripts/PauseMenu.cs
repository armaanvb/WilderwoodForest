using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public Canvas pauseCanvas;
	public Canvas optionsCanvas;

	float volume;
	bool gunState = false;
	bool meleeState = false;
	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F1))
		{
			if(Time.timeScale == 1)
			{
				(GameObject.Find("Player").GetComponent("MouseLook") as MonoBehaviour).enabled = false;
				pauseCanvas.enabled = true;
				Time.timeScale = 0;
				Screen.lockCursor = false;
				Screen.showCursor = true;

				if((GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled == true)
				{
					(GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled = false;
					gunState = true;
				}

				if((GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled == true)
				{
					(GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled = false;
					meleeState = true;
				}
			}
			else
			{
				(GameObject.Find("Player").GetComponent("MouseLook") as MonoBehaviour).enabled = true;
				pauseCanvas.enabled = false;
				optionsCanvas.enabled = false;
				Time.timeScale = 1;
				Screen.lockCursor = true;
				Screen.showCursor = false;
				
				if(gunState)
				{
					(GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled = true;
					gunState = false;
				}
				
				if(meleeState)
				{
					(GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled = true;
					meleeState = false;
				}
			}
		}
	}

	public void ResumeGame()
	{
		(GameObject.Find("Player").GetComponent("MouseLook") as MonoBehaviour).enabled = true;
		pauseCanvas.enabled = false;
		optionsCanvas.enabled = false;
		Time.timeScale = 1;
		Screen.lockCursor = true;
		Screen.showCursor = false;

		if(gunState)
		{
			(GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled = true;
			gunState = false;
		}

		if(meleeState)
		{
			(GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled = true;
			meleeState = false;
		}
	}

	public void OptionsMenu()
	{
		pauseCanvas.enabled = !pauseCanvas.enabled;
		optionsCanvas.enabled = !optionsCanvas.enabled;
	}

	public void Back()
	{
		pauseCanvas.enabled = !pauseCanvas.enabled;
		optionsCanvas.enabled = !optionsCanvas.enabled;
	}

	public void AudioSlider(float value)
	{
		volume = AudioListener.volume = value;
	}

	public void QuitToMainMenu()
	{
		Application.LoadLevel("MainMenu");
	}

	public void QuitToDesktop()
	{
		Application.Quit();
	}

	public void PauseMobile()
	{
		if(Time.timeScale == 1)
		{
			(GameObject.Find("Player").GetComponent("MouseLook") as MonoBehaviour).enabled = false;
			pauseCanvas.enabled = true;
			Time.timeScale = 0;
			Screen.lockCursor = false;
			Screen.showCursor = true;
			
			if((GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled == true)
			{
				(GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled = false;
				gunState = true;
			}
			
			if((GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled == true)
			{
				(GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled = false;
				meleeState = true;
			}
		}
		else
		{
			(GameObject.Find("Player").GetComponent("MouseLook") as MonoBehaviour).enabled = true;
			pauseCanvas.enabled = false;
			optionsCanvas.enabled = false;
			Time.timeScale = 1;
			Screen.lockCursor = true;
			Screen.showCursor = false;
			
			if(gunState)
			{
				(GameObject.Find("Player").GetComponent("gunstate") as MonoBehaviour).enabled = true;
				gunState = false;
			}
			
			if(meleeState)
			{
				(GameObject.Find("Player").GetComponent("meleestate") as MonoBehaviour).enabled = true;
				meleeState = false;
			}
		}
	}
}
