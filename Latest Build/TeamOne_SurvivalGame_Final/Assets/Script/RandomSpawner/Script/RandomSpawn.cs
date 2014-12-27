using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour 
{
	public Transform spawn01;
	public Transform spawn02;
	public Transform spawn03;
	public Transform spawn04;
	
	void Start () 
	{
		int spawnChoice = Random.Range (0, 4);
		
		if(spawnChoice == 0)
		{
			transform.position = spawn01.position;
		}
		
		if(spawnChoice == 1)
		{
			transform.position = spawn02.position;
		}
		
		if(spawnChoice == 2)
		{
			transform.position = spawn03.position;
		}
		
		if(spawnChoice == 3)
		{
			transform.position = spawn04.position;
		}
	}
}
