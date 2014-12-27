using UnityEngine;
using System.Collections;

public class ItemDurability : MonoBehaviour
{
	public float itemDurability = 0;

	void Update () 
	{
		if(itemDurability <= 0)
		{
			GameObject.Find("Player").GetComponent<meleestate>().transform.FindChild("Sword").gameObject.SetActive(false);
		}

		if(itemDurability <= 0){itemDurability = 0;}
	}
}
