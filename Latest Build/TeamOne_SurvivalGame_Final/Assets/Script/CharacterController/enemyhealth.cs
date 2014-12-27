using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour {

	public int maxHealth= 100;
	public int curHealth=100;
	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth < 0)
			Destroy (enemy); 
	}
	
	void OnGUI () {
		GUI.Box (new Rect (10, 40, Screen.width / 15, 20), curHealth + "/" + maxHealth);
	}

	public void adjustCurHealth (int adj) {
		curHealth += adj;

}
}