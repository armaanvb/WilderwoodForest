using UnityEngine;
using System.Collections;

public class NodeScript : MonoBehaviour 
{
	public bool pull;
	private float speed;

	private float scanFrequency = 1.0f;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("ScanForTarget", 0, scanFrequency );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pull)
		{
			EnemyPull();
		}
	}

	void ScanForTarget()
	{
		GetNearestTaggedObject();
	}

	Transform GetNearestTaggedObject()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("EnemyRoam");
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
	
	void EnemyPull()
	{
		GetNearestTaggedObject().transform.LookAt (transform);
		speed = GetNearestTaggedObject().GetComponent<EnemyRoaming>().speed;
		
		float step = speed * Time.deltaTime;
		GetNearestTaggedObject().GetComponent<EnemyRoaming>().transform.position = 
			Vector3.MoveTowards(GetNearestTaggedObject().GetComponent<EnemyRoaming>().transform.position, transform.position, step);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "EnemyRoam")
		{
			GetNearestTaggedObject().GetComponent<EnemyRoaming>().isRoam = true;
			Destroy(gameObject);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "EnemyRoam")
		{
			GetNearestTaggedObject().GetComponent<EnemyRoaming>().isRoam = true;
			Destroy(gameObject);
		}
	}
}
