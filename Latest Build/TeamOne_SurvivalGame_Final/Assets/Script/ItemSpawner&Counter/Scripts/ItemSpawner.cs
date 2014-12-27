using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour 
{
	public GameObject item01;
	public GameObject item02;
	public GameObject item03;
	public GameObject item04;
	public GameObject itemEmpty;
	public bool spawn = false;

	public int itemSpawned;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(spawn == true)
		{
			int randomPick = Random.Range (0, 5);
			if(randomPick == 0)
			{
				GameObject itemOne = Instantiate(item01, transform.position, Quaternion.identity) as GameObject;
				itemOne.transform.parent = transform;
				spawn = false;
				itemSpawned++;
			}
			if(randomPick == 1)
			{
				GameObject itemTwo = Instantiate(item02, transform.position, Quaternion.identity) as GameObject;
				itemTwo.transform.parent = transform;
				spawn = false;
				itemSpawned++;
			}
			if(randomPick == 2)
			{
				GameObject itemThree = Instantiate(item03, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
				itemThree.transform.parent = transform;
				spawn = false;
				itemSpawned++;
			}
			if(randomPick == 3)
			{
				GameObject itemFour = Instantiate(itemEmpty, transform.position, Quaternion.identity) as GameObject;
				itemFour.transform.parent = transform;
				spawn = false;
				itemSpawned++;
			}
			if(randomPick == 4)
			{
				GameObject itemThree = Instantiate(item04, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
				itemThree.transform.parent = transform;
				spawn = false;
				itemSpawned++;
			}
		}
	}
}
