using UnityEngine;
using System.Collections;

[System.Serializable]
public class TrapsDoor : MonoBehaviour {

	DoorControl control;
	public bool ResetTrapTimer ;
	public float ResetTrapTime ;
	public float RiseTime ;
	
	public bool OpenNormallyWithoutTrapping ;

	public float WarningTime ;
	public float FallTime ;
	public float DamageAmount ;

	// Use this for initialization
	void Start () {
		control = GetComponent<DoorControl> ();
		if (control != null)
			control.OnActivate += TrapDatJunk;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//did the door touch the player?
	void OnTriggerEnter(Collider other) {
		PlayerControls.DamagePlayer (DamageAmount);
	}

	void TrapDatJunk( Vector3 location ) {
		if (OpenNormallyWithoutTrapping) {
			//start opening
			StartCoroutine ("OpenAnimation");
		}
		else {
			//get direction to fall at
			var activatorDir = location - transform.position;
			var frontOfDoor = transform.forward; //new Vector3( 0, 1, 1 );

			var direction = Vector3.Dot(activatorDir, frontOfDoor);
			//start the trap sequence
			StartCoroutine ("TrapAnimation", direction > 0);
		}
	}

	IEnumerator OpenAnimation() {
		yield return null;
	}

	IEnumerator TrapAnimation( bool fallForward ) {
		var start = Time.time;
		var startingRotation = transform.rotation.eulerAngles;
		var rotationOrigin = transform.position + new Vector3 (0, -1.5f, 0);
		var rotationAxis = new Vector3 (1.0f, 0f, 0f);

		Debug.Log ("Trap Triggered");
		//warn the player (TODO)
		//now fall toward the activator
		var bocks = GetComponent<BoxCollider> ();
		if (bocks != null) {
			bocks.isTrigger = true;
		}
		start = Time.time;
		while (Time.time - start < FallTime) {
			var fallRate = 90 * (Time.deltaTime / FallTime);
			if (!fallForward)
				fallRate = -fallRate;

			transform.RotateAround(rotationOrigin, rotationAxis, fallRate);
			yield return null;
		}
		if (bocks != null) {
			bocks.isTrigger = false;
		}
		//and rest as a simple collider
		if (ResetTrapTimer) {
			yield return new WaitForSeconds(ResetTrapTime);
			start = Time.time;
			while (Time.time - start < RiseTime) {
				var riseRate = 90 * (Time.deltaTime / RiseTime);
				if (fallForward)
					riseRate = -riseRate;

				transform.RotateAround(rotationOrigin, rotationAxis, riseRate);
				yield return null;
			}
			Debug.Log ("Trap done rising");
		}
		Debug.Log("Trap finished");
	}
}
