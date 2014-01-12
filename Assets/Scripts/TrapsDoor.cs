﻿using UnityEngine;
using System.Collections;

public class TrapsDoor : MonoBehaviour {

	DoorControl control;
	public bool ResetTrapTimer { get; set; }
	public float ResetTrapTime { get; set; }
	public float RiseTime { get; set; }
	
	public bool OpenNormallyWithoutTrapping { get; set; }

	public float WarningTime { get; set; }
	public float FallTime { get; set; }
	public float DamagePercent { get; set; }

	// Use this for initialization
	void Start () {
		ResetTrapTime = 2.0f;
		control = GetComponent<DoorControl> ();
		if (control != null)
			control.OnActivate += TrapDatJunk;
		FallTime = 3;
		ResetTrapTimer = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//did the door touch the player?
	void OnTriggerEnter(Collider other) {
		Respawn.KillPlayer ();
	}

	void TrapDatJunk( Vector3 location ) {
		if (OpenNormallyWithoutTrapping) {
			//start opening
			StartCoroutine ("OpenAnimation");
		}
		else {
			//get direction to fall at
			var activatorDir = location - transform.position;
			var frontOfDoor = new Vector3( 0, 1, 1 );//TODO make this really the front of the door vector

			var direction = Vector3.Dot(activatorDir, frontOfDoor);
			//start the trap sequence
			StartCoroutine ("TrapAnimation", direction > 0);
		}
	}

	IEnumerator OpenAnimation() {
		yield return null;
	}

	IEnumerator TrapAnimation( bool fallForward ) {
		float start = Time.time;
		Vector3 startingRotation = transform.rotation.eulerAngles;

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

			transform.Rotate(new Vector3(fallRate, 0, 0));
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
				
				transform.Rotate(new Vector3(riseRate, 0, 0));
				yield return null;
			}
			Debug.Log ("Trap done rising");
		}
		Debug.Log("Trap finished");
	}
}