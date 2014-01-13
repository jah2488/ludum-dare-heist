using UnityEngine;
using System.Collections;

[System.Serializable]
public class Trigger : MonoBehaviour {

	public string TriggerIdentifier;
	
	public delegate void GlobalActivateCallback(Vector3 location, string triggerIdentifier);
	public static event GlobalActivateCallback OnActivateGlobal;

	AlertOnPlayer alert = null;

	// Use this for initialization
	void Start () {
		if (transform != null && transform.parent != null)
			alert = transform.parent.GetComponent<AlertOnPlayer> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" && alert != null) {
			alert.TriggerEntered();
		}
		Debug.Log("Calling for activation of " + TriggerIdentifier);
		if (!string.IsNullOrEmpty(TriggerIdentifier.Trim())){
			ActivateGlobal(transform.position, TriggerIdentifier.Trim().ToUpper());
		}
		AlarmManager.Alert();
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" && alert != null) {
			alert.TriggerExit();
		}
	}

	public static void ActivateGlobal(Vector3 location, string triggerIdentifier){
		if (OnActivateGlobal != null)
			OnActivateGlobal (location, triggerIdentifier);
	}
}
