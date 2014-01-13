using UnityEngine;
using System.Collections;

[System.Serializable]
public class ButtonControl : MonoBehaviour {
	
	public float DistanceToActivate;
	public string TriggerIdentifier;

	public delegate void ActivateCallback(Vector3 location, string triggerIdentifier);
	public event ActivateCallback OnActivate;
	
	public delegate void GlobalActivateCallback(Vector3 location, string triggerIdentifier);
	public static event GlobalActivateCallback OnActivateGlobal;
	
	// Use this for initialization
	void Start () {
		PlayerControls.OnUse += OnPlayerUse;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnPlayerUse( Vector3 location ){
		var dist = Vector3.Distance (transform.position, location);
		if (dist < DistanceToActivate) {
			if (OnActivate != null){
				Debug.Log("Activating the button.");
				OnActivate(location, TriggerIdentifier);
			}
			else
				Debug.Log("No button to activate!");

			//do global triggers
			if (!string.IsNullOrEmpty(TriggerIdentifier.Trim()))
				ActivateGlobal(location, TriggerIdentifier.Trim().ToUpper());
		}
		else {
			//Debug.Log("Distance of " + dist + " is too far from door (needs " + DistanceToActivate + " to trigger) ");
		}
	}

	public static void ActivateGlobal(Vector3 location, string triggerIdentifier){
		if (OnActivateGlobal != null)
			OnActivateGlobal (location, triggerIdentifier);
	}
}
