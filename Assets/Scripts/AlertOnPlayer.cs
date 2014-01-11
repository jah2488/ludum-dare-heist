using UnityEngine;
using System.Collections;

public class AlertOnPlayer : MonoBehaviour {

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {

		}

		public void TriggerEntered() {
				GetComponentInChildren<Light>().color = Color.red;
		}

		public void TriggerExit() {
				GetComponentInChildren<Light>().color = Color.cyan;
		}

}
