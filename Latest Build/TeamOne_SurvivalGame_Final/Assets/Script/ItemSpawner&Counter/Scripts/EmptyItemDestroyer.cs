using UnityEngine;
using System.Collections;

public class EmptyItemDestroyer : MonoBehaviour 
{
	public float itemTime = 3f;
	
	void Update () 
	{
		itemTime -= Time.deltaTime * 1f;
		
		if(itemTime <= 0)
		{
			transform.parent.gameObject.GetComponent<ItemSpawner>().spawn = true;
			Destroy(gameObject);
		}
	}
}
