using UnityEngine;
using System.Collections;

public class Bodyguard : MonoBehaviour 
{
	public Transform player;
	public float followDist;
	public float chaseSpeed;
	public float stopSpeed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		{
			float distance = Vector3.Distance(player.position, transform.position);
			
			if(distance >= followDist)
			{
				BeginChase();
			}
			else if (distance <= followDist)
			{
				EndChase();
			}
		}
	}

	void BeginChase()
	{
		transform.LookAt(player);
		float step = chaseSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, player.position, step);
	}

	void EndChase()
	{
		transform.LookAt(player);
		float step = stopSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, player.position, step);
	}
}
