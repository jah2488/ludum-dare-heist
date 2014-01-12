using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	public float DistanceToActivate { get; set; }

	public delegate void ActivateCallback(Vector3 location);
	public event ActivateCallback OnActivate;

	// Use this for initialization
	void Start () {
		PlayerControls.OnUse += OnPlayerUse;
		DistanceToActivate = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPlayerUse( Vector3 location ){
		var dist = Vector3.Distance (transform.position, location);
		if (dist < DistanceToActivate) {
			if (OnActivate != null){
				Debug.Log("Activating door.");
				OnActivate(location);
			}
			else
				Debug.Log("No door to activate!");
		}
		else {
			Debug.Log("Distance of " + dist + " is too far from door (needs " + DistanceToActivate + " to trigger) ");
		}
	}
}
