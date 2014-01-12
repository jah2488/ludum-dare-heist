using UnityEngine;
using System.Collections;

[System.Serializable]
public class HealthControl : MonoBehaviour {

	float resetHealthLevel;
	public float Health;

	// Use this for initialization
	void Start () {
		if (Health <= 0)
			Health = 100;
		resetHealthLevel = Health;
		PlayerControls.OnDamagePlayer += Damage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Die(){
		Respawn.KillPlayer ();
		Health = resetHealthLevel;
	}

	void Damage(float ouch){
		if (Health - ouch <= 0)
			Die ();
		else
			Health -= ouch;
	}

}
