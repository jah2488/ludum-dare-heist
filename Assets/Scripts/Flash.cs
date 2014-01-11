using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
		bool down;
		Light light;

		void Start ()
		{
				light = GetComponent<Light>();
		}

		void Update ()
		{
				if(light.intensity < 0.45) {
						down = false;
				}
				if(light.intensity > 2.0) {
						down = true;
				}

				if (down) {
						light.intensity -= 1f * Time.deltaTime;
				} else {
						light.intensity += 1f * Time.deltaTime;
				}
		}
}
