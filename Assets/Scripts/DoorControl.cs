using UnityEngine;
using System.Collections;

[System.Serializable]
public class DoorControl : MonoBehaviour {

	public float DistanceToActivate;
	public string TriggerIdentifier;

	public delegate void ActivateCallback(Vector3 location);
	public event ActivateCallback OnActivate;

	// Use this for initialization
	void Start () {
		PlayerControls.OnUse += OnPlayerUse;
		if (!string.IsNullOrEmpty (TriggerIdentifier.Trim ())) {
			ButtonControl.OnActivateGlobal += HandleOnActivateGlobal;
			Trigger.OnActivateGlobal += HandleOnActivateGlobal;
		}
	}

	void HandleOnActivateGlobal (Vector3 location, string triggerIdentifier)
	{
		if (triggerIdentifier.Trim ().ToUpper () == TriggerIdentifier.Trim ().ToUpper ()) {
			if (OnActivate != null){
				OnActivate (location);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPlayerUse( Vector3 location ){
		var dist = Vector3.Distance (transform.position, location);
		if (dist < DistanceToActivate) {
			if (OnActivate != null){
				OnActivate(location);
			}
			else
				Debug.Log("No door to activate!");
		}
		else {
			//Debug.Log("Distance of " + dist + " is too far from door (needs " + DistanceToActivate + " to trigger) ");
		}
	}
}
