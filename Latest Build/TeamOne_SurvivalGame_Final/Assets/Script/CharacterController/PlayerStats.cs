using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour 
{
	public float maxHealth;
	public float curHealth;
	public float speedHealth;

	public float maxFood;
	public float curFood;
	public float speedFood;

	public float maxHydration;
	public float curHydration;
	public float speedHydration;

	public float foodBuff;
	public float waterBuff;

	public Text healthGUI;
	public Text foodGUI;
	public Text waterGUI;
	public Text foodBuffGUI;
	public Text waterBuffGUI;

	private float foodTemp;
	private float waterTemp;

	// Use this for initialization
	void Start () 
	{
		foodTemp = speedFood;
		waterTemp = speedHydration;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// HEALTH STATS
		if (curHealth >= maxHealth)
		{
			curHealth = maxHealth;
		}

		if (curHealth <= 0)
		{
			print ("Died!");
			curHealth = 0;
			Application.LoadLevel("DeathScreen");
			Destroy (gameObject, 1.0f);
		}

		// FOOD STATS
		if (curFood >= maxFood)
		{
			curFood = maxFood;
		}

		if (curFood <= 0)
		{
			curHealth -= Time.deltaTime * speedHealth;
			curFood = 0;
		}

		if (curFood == maxFood && curHealth < maxHealth)
		{
			curHealth += Time.deltaTime * speedHealth;
		}

		curFood -= Time.deltaTime * speedFood;

		// HYDRATION STATS

		if (curHydration >= maxHydration)
		{
			curHydration = maxHydration;
		}

		if (curHydration <= 0)
		{
			print ("Dehydrated!");
			Application.LoadLevel("DeathScreen");
			Destroy(gameObject);
		}

		curHydration -= Time.deltaTime * speedHydration;

		// BUFFS

		if(foodBuff > 0){curFood = maxFood; speedFood = 0; foodBuff -= Time.deltaTime * 1;}
		if(foodBuff <= 0){foodBuff = 0; speedFood = foodTemp;}
		if(waterBuff > 0){curHydration = maxHydration; speedHydration = 0; waterBuff -= Time.deltaTime * 1;}
		if(waterBuff <= 0){waterBuff = 0; speedHydration = waterTemp;}

		healthGUI.text = "Health: " + curHealth.ToString("0") + "/" + maxHealth;
		foodGUI.text = "Food: " + curFood.ToString("0") + "/" + maxFood;
		waterGUI.text = "Water: " + curHydration.ToString("0") + "/" + maxHydration;
		foodBuffGUI.text = "Food Buff:" + foodBuff.ToString("0");
		waterBuffGUI.text = "Water Buff:" + waterBuff.ToString("0");
	}

	public void adjustCurHealth (int adj) 
	{
		curHealth += adj;	
	}
}

