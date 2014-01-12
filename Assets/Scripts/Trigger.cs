using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

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
		AlarmManager.Alert();
		}

		void OnTriggerExit(Collider other) {
			if(other.tag == "Player" && alert != null) {
				alert.TriggerExit();
			}
		}

}
