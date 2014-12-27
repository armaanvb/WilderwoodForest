using UnityEngine;
using System.Collections;

public class EnemyRoamingInvis : MonoBehaviour 
{
	public float maxX;
	public float minX;
	public float maxZ;
	public float minZ;
	public float currentX;
	public float currentZ;

	public GameObject node;
	public float speed;
	public bool isRoam = true;

	public float randX;
	public float randZ;

	//--------------------------------

	public Transform player;
	public float followDist;
	public float chaseSpeed;
	public int nodeCounter;

	//--------------------------------

	private float scanFrequency = 1.0f;
	public Transform target;

	//--------------------------------

	public Transform spawnPoint;

	void Start () 
	{
		player = GameObject.Find("Player").transform;
		spawnPoint = GetNearestTaggedNode();
		InvokeRepeating("ScanForTarget", 0, scanFrequency );
		transform.FindChild("Ghost").renderer.enabled = false;
	}
	

	void Update () 
	{
		Roam ();
		Chase();

		if(GameObject.Find("FlashlightTrigger").GetComponent<BoxCollider>().isTrigger == false)
		{
			transform.FindChild("Ghost").renderer.enabled = false;
		}
	}

	void ScanForTarget()
	{
		target = GetNearestTaggedObject();
	}

	Transform GetNearestTaggedObject()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("RoamNode");
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

	void Chase()
	{
		if(player)
		{
			float distance = Vector3.Distance(player.position, transform.position);
			
			if(distance <= followDist)
			{
				GetNearestTaggedObject().GetComponent<NodeScriptInvis>().pull = false;
				transform.LookAt(player);
				float step = chaseSpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, player.position, step);
			}
			
			if(distance >= followDist)
			{
				GetNearestTaggedObject().GetComponent<NodeScriptInvis>().pull = true;
			}
		}
	}

	void Roam()
	{
		currentX = transform.position.x;
		currentZ = transform.position.z;
		
		if(isRoam && currentX <= maxX && currentX >= minX && currentZ <= maxZ && currentZ >= minZ)
		{
			RoamXZ();
		}
		
		if(isRoam && currentX <= maxX && currentZ >= maxZ)
		{
			RoamX();
		}
		
		if(isRoam && currentX <= minX && currentZ >= minZ)
		{
			RoamNX();
		}
		
		if(isRoam && currentX >= maxX && currentZ <= maxZ)
		{
			RoamZ();
		}
		
		if(isRoam && currentX >= minX && currentZ <= minZ)
		{
			RoamNZ();
		}
		
		if(isRoam && currentX >= maxX && currentZ >= maxZ)
		{
			RoamBack();
		}
		
		if(isRoam && currentX <= minX && currentZ <= minZ)
		{
			RoamNBack();
		}
	}

	void RoamXZ()
	{
		randX = Random.Range(currentX - 5, currentX + 6);
		randZ = Random.Range(currentZ - 5, currentZ + 6);
		Instantiate(node, new Vector3(randX, transform.position.y, randZ), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamX()
	{
		randX = Random.Range(currentX - 5, currentX + 6);
		if(currentX >= maxX){randX = randX - 5;}
		Instantiate(node, new Vector3(randX, transform.position.y, transform.position.z - 3), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamNX()
	{
		randX = Random.Range(currentX - 5, currentX + 6);
		if(currentX <= maxX){randX = randX + 5;}
		Instantiate(node, new Vector3(randX, transform.position.y, transform.position.z + 3), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamZ()
	{
		randZ = Random.Range(currentZ - 5, currentZ + 6);
		if(currentZ >= maxZ){randZ = randZ - 5;}
		Instantiate(node, new Vector3(transform.position.x - 3, transform.position.y, randZ), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamNZ()
	{
		randZ = Random.Range(currentZ - 5, currentZ + 6);
		if(currentZ <= maxZ){randZ = randZ + 5;}
		Instantiate(node, new Vector3(transform.position.x + 3, transform.position.y, randZ), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamBack()
	{
		randX = Random.Range(currentX - 5, currentX + 6);
		if(currentX >= maxX){randX = randX - 5;}
		randZ = Random.Range(currentZ - 5, currentZ + 6);
		if(currentZ >= maxZ){randZ = randZ - 5;}
		Instantiate(node, new Vector3(randX, transform.position.y, randZ), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void RoamNBack()
	{
		randX = Random.Range(currentX - 5, currentX + 6);
		if(currentX <= maxX){randX = randX + 5;}
		randZ = Random.Range(currentZ - 5, currentZ + 6);
		if(currentZ <= maxZ){randZ = randZ + 5;}
		Instantiate(node, new Vector3(randX, transform.position.y, randZ), Quaternion.identity);
		nodeCounter++;
		isRoam = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "FlashlightTrigger")
		{
			transform.FindChild("Ghost").renderer.enabled = true;
			Color color = transform.FindChild("Ghost").renderer.material.color;
			color.a = 0.5f;
			transform.FindChild("Ghost").renderer.material.color = color;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "FlashlightTrigger")
		{
			transform.FindChild("Ghost").renderer.enabled = true;
			Color color = transform.FindChild("Ghost").renderer.material.color;
			color.a = 0.5f;
			transform.FindChild("Ghost").renderer.material.color = color;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "FlashlightTrigger")
		{
			transform.FindChild("Ghost").renderer.enabled = false;
		}
	}

	Transform GetNearestTaggedNode()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("spawnNodes");
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














