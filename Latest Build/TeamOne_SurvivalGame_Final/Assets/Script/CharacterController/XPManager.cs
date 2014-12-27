using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XPManager : MonoBehaviour 
{
	public Text levelText;
	public int level;
	public int curExperience;
	public int maxExperience;
	public int receivedExperience;

	private int tempExperience;
	private int leftoverExperience;

	public Scrollbar XPBar;

	public int FoodGuardXPReward;
	public int GuardXPReward;
	public int RoamerXPReward;
	public int RoamerInvisXPReward;
	// Use this for initialization
	void Start () 
	{
		XPBar.size = (float)curExperience / (float)maxExperience;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(receivedExperience > 0)
		{
			ExperienceGain();
		}

		if(Input.GetKeyDown(KeyCode.Y))
		{
			receivedExperience = 50;
			print("50 XP Hack!");
		}

		levelText.text = level.ToString("0");
	}

	void LevelUp()
	{
			level++;
			curExperience = 0;
			maxExperience = (maxExperience * 2) - 50;
			curExperience += leftoverExperience;
			XPBar.size = (float)curExperience / (float)maxExperience;
			leftoverExperience = 0;
	}

	void ExperienceGain()
	{
		tempExperience = maxExperience - curExperience;
		if(tempExperience <= receivedExperience)
		{
			curExperience += tempExperience;
			leftoverExperience = receivedExperience - tempExperience;
			XPBar.size = (float)curExperience / (float)maxExperience;
			receivedExperience = 0;
			tempExperience = 0;
			if(curExperience >= maxExperience){LevelUp();}
		}
		else
		{
			curExperience += receivedExperience;
			XPBar.size = (float)curExperience / (float)maxExperience;
			receivedExperience = 0;
			tempExperience = 0;
			if(curExperience >= maxExperience){LevelUp();}
		}
	}
}
