using UnityEngine;
using System.Collections;

public class State : MonoBehaviour
{
	protected PlayerController player;

	//Enter statemachine script (No need to touch)
	public virtual void EnterState(PlayerController player)
	{
		this.player = player;
		this.enabled = true;
	}

	public virtual void Update() { }
	//Exit statemachine script (no need to touch)
	public virtual void ExitState()
	{ 
		this.enabled = false;
		print("Exiting state " + this);
	}
}
