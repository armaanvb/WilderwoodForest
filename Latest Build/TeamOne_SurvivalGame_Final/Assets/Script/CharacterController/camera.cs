using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	//the taget in which the camera follows
	public Transform target;



	
	// Update is called once per frame
	void Update () {

				//the position of the camera = the position of the target
				transform.position = target.position - transform.forward * 20;

		}
}
