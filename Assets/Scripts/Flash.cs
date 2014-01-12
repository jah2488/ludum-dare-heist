using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
		bool down;
		Light light;
		bool alerted;

		void AlertToggle(Vector3 pos){
			//alerted = !alerted; //this doesn't work!
			alerted = true;
			Debug.Log ("Set light:alerted to be " + alerted);
		}

		void Start ()
		{
			light = GetComponent<Light>();
			alerted = false;
			AlarmManager.OnOhSnap += AlertToggle;
		}

		void Update ()
		{
			if (alerted) {
				if (light.intensity < 0.45) {
						down = false;
				}
				if (light.intensity > 2.0) {
						down = true;
				}

				if (down) {
						light.intensity -= 1f * Time.deltaTime;
				} else {
						light.intensity += 1f * Time.deltaTime;
				}
			}
		}
}
