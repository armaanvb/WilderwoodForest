using UnityEngine;
using System.Collections;

public class EnemyAIGuard : MonoBehaviour 
{
	public Transform guardPoint;
	public Transform player;
	public float chaseSpeed;
	public float returnSpeed;
	public float followDist;
	public float tempfollowDist;
	
	// Use this for initialization
	void Start () 
	{
		guardPoint = GetNearestTaggedObject();
		tempfollowDist = followDist;
	}
	
	// Update is called once per frame
	void Update () 
	{
		player = GameObject.Find("Player").transform;

		if(player)
		{
			float distance = Vector3.Distance(player.position, transform.position);

			if(distance <= followDist)
			{
				BeginChase();
			}
			else
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
		transform.LookAt(guardPoint);
		float step = returnSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, guardPoint.position, step);
	}

	Transform GetNearestTaggedObject()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("guardNodes");
		Transform closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			
			if(curDistance < distance)
			{
				closest = go.transform;
				distance = curDistance;
			}
		}
		return closest;
	}
}
